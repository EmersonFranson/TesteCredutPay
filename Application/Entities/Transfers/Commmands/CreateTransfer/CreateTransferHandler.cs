using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Transfers.Commmands.CreateTransfer
{
    public class CreateTransferHandler : IRequestHandler<CreateTransferCommand, Guid>
    {
        private readonly ITransferRepository _transferRepository;
        public CreateTransferHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public async Task<Guid> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = new Transfer
            {
                Id = Guid.NewGuid(),
                IdOriginUser = request.IdOriginUser,
                TransferValue = request.Amount,
                IdDestinyUser = request.IdDestinyUser,
                DtTransfer = DateTime.UtcNow
            };
            await _transferRepository.AddAsync(transfer);
            return transfer.Id;
        }
    }    
}
