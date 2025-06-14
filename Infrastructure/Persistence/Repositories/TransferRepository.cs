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
            //aqui vai ter a lógica para adicionar saldo a carteira do usuário
            var walletOrigin = await _context.Wallets
                .FirstOrDefaultAsync(w => w.IdUser == transfer.IdOriginUser);

            var walletDestiny = await _context.Wallets
                .FirstOrDefaultAsync(w => w.IdUser == transfer.IdDestinyUser);

            walletDestiny.Balance += transfer.TransferValue;
            walletOrigin.Balance -= transfer.TransferValue;

            await _context.Transactions.AddAsync(transfer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transfer>> GetByUserIdAsync(Guid userId, DateTime? dateInit, DateTime? dateEnd)
        {
            var query = _context.Transactions
                .Where(t => t.IdOriginUser == userId);

            if (dateInit.HasValue)
            {
                var dateInitUtc = DateTime.SpecifyKind(dateInit.Value, DateTimeKind.Utc);
                query = query.Where(t => t.DtTransfer >= dateInitUtc);
            }

            if (dateEnd.HasValue)
            {
                var dateEndUtc = DateTime.SpecifyKind(dateEnd.Value, DateTimeKind.Utc);
                query = query.Where(t => t.DtTransfer <= dateEndUtc);
            }

            return await query.ToListAsync();
        }
    }
}
