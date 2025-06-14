using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Wallets.Commands.AddWalletBalance.AddWallet
{
    public class AddBalanceWalletHandler : IRequestHandler<AddBalanceWalletCommand, Guid>
    {
        private readonly IWalletRepository _walletRepository;
        public AddBalanceWalletHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Guid> Handle(AddBalanceWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = new Wallet
            {
                IdUser = request.UserId,
                NameWallet = request.NameWallet,
                Balance = 0 // Initialize balance to zero
            };
            await _walletRepository.AddAsync(wallet);
            
            var response = await _walletRepository.GetByUserIdAsync(request.UserId);
            return response.Id;
        }
    }
}
