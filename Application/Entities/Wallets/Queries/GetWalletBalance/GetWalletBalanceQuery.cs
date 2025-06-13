using MediatR;

namespace Application.Entities.Wallets.Queries.GetWalletBalance
{
    public record GetWalletBalanceQuery(Guid UserId) : IRequest<decimal>;
}
