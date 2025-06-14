using MediatR;

namespace Application.Entities.Wallets.Commands.AddWalletBalance.AddWallet
{
    public class AddBalanceWalletCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string NameWallet { get; set; }
    }
}
