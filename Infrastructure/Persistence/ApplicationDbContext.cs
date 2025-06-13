using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transfer> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("wallets");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Id)
                      .HasColumnName("id")
                      .IsRequired();

                entity.Property(w => w.IdUser)
                      .HasColumnName("user_id")
                      .IsRequired();

                entity.Property(w => w.NameWallet)
                      .HasColumnName("wallet_name")
                      .IsRequired();

                entity.Property(w => w.Balance)
                      .HasColumnName("balance")
                      .IsRequired()
                      .HasColumnType("numeric(18,2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(u => u.id);

                entity.Property(u => u.id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(u => u.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Phone)
                    .HasColumnName("phone")
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(u => u.DtBirth)
                    .HasColumnName("dt_birth")
                    .IsRequired();
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.ToTable("transfers");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(t => t.IdOriginWallet)
                    .HasColumnName("from_wallet_id")
                    .IsRequired();

                entity.Property(t => t.IdDestinyWallet)
                    .HasColumnName("to_wallet_id")
                    .IsRequired();

                entity.Property(t => t.TransferValue)
                    .HasColumnName("transfer_value")
                    .IsRequired()
                    .HasColumnType("numeric(18,2)");

                entity.Property(t => t.DtTransfer)
                    .HasColumnName("transfer_date")
                    .IsRequired()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
