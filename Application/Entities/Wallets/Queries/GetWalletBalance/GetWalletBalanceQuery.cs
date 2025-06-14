using Domain.Entities;
using MediatR;

namespace Application.Entities.Wallets.Queries.GetWalletBalance
{
    public record GetWalletBalanceQuery : IRequest<Wallet>
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
