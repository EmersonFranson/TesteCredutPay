using MediatR;

namespace Application.Entities.Transfers.Commmands.CreateTransfer
{
    public record CreateTransferCommand : IRequest<Guid>
    {
        public Guid IdOriginUser { get; set; }
        public Guid IdDestinyUser { get; set; }
        public decimal Amount { get; set; }
    }
}
