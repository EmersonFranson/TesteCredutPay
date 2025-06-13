using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Wallets.Queries.GetWalletBalance
{
    public class GetWalletBalanceHandler : IRequestHandler<GetWalletBalanceQuery, decimal>
    {
        private readonly IWalletRepository _walletRepository;

        public GetWalletBalanceHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<decimal> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetByUserIdAsync(request.UserId);
            return wallet?.Balance ?? 0m;
        }
    }
}
