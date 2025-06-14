using Domain.Entities;
using MediatR;

namespace Application.Entities.Wallets.Commands.AddWalletBalance.AddBalance
{
    public class PutWalletBalanceCommand : IRequest<Wallet>
    {
        public Guid IdUser { get; set; }
        public decimal Value { get; set; }
    }
}
