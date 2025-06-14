using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Wallets.Commands.AddWalletBalance.AddBalance
{
    public class PutWalletBalanceHandler : IRequestHandler<PutWalletBalanceCommand, Wallet>
    {
        private readonly IWalletRepository _walletRepository;
        public PutWalletBalanceHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async Task<Wallet> Handle(PutWalletBalanceCommand request, CancellationToken cancellationToken)
        {
           var wallet = await _walletRepository.GetByUserIdAsync(request.IdUser);
            if (wallet == null)
            {
                wallet = new Wallet
                {
                    IdUser = request.IdUser,
                    Balance = request.Value
                };
                await _walletRepository.AddAsync(wallet);
            }
            else
            {
                wallet.Balance += request.Value;
                await _walletRepository.UpdateAsync(wallet);
            }            
            return wallet;
        }       
    }    
}
