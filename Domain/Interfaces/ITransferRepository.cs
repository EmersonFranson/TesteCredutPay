using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITransferRepository
    {
        Task<IEnumerable<Transfer>> GetByUserIdAsync(Guid userId,DateTime? dateInit, DateTime? dateEnd);
        Task AddAsync(Transfer transfer);
    }
}
