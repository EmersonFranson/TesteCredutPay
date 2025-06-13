using MediatR;

namespace Application.Entities.Transfers.Queries.GetUserTransfers
{
    public record GetUserTransfersQuery(Guid TransferId) : IRequest<decimal>;   
}
