using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Transfers.Queries.GetUserTransfers
{
    public class GetUserTransfersHandler : IRequestHandler<GetUserTransfersQuery, IEnumerable<Transfer>>
    {
        private readonly ITransferRepository _transferRepository;
        public GetUserTransfersHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public async Task<IEnumerable<Transfer>> Handle(GetUserTransfersQuery request, CancellationToken cancellationToken)
        {
           return await _transferRepository.GetByUserIdAsync(request.UserId,request.dateInit, request.dateEnd);            
        }
    }    
}
