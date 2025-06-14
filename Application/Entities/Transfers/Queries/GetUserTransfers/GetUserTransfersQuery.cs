using Domain.Entities;
using MediatR;

namespace Application.Entities.Transfers.Queries.GetUserTransfers
{
    public record GetUserTransfersQuery : IRequest<IEnumerable<Transfer>>
    {
        public Guid UserId { get; set; }
        public DateTime? dateInit { get; set; }
        public DateTime? dateEnd { get; set; }
    }
}
