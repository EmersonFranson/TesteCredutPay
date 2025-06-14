using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Wallets.Queries.GetWalletBalance
{
    public class GetWalletBalanceHandler : IRequestHandler<GetWalletBalanceQuery, Wallet>
    {
        private readonly IWalletRepository _walletRepository;

        public GetWalletBalanceHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Wallet> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetByUserIdAsync(request.UserId);           
        }
    }
}
