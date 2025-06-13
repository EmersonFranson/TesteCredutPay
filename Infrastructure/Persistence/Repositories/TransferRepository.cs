using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transfer transfer)
        {
            await _context.Transactions.AddAsync(transfer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transfer>> GetByUserIdAsync(Guid userId, DateTime? dateInit, DateTime? dateEnd)
        {
            var query = _context.Transactions
                .Where(t => t.IdOriginWallet == userId);

            if (dateInit.HasValue)
            {
                query = query.Where(t => t.DtTransfer >= dateInit.Value);
            }

            if (dateEnd.HasValue)
            {
                query = query.Where(t => t.DtTransfer <= dateEnd.Value);
            }

            return await query.ToListAsync();
        }
    }
}
