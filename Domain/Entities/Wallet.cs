namespace Domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string NameWallet { get; set; }
        public decimal Balance { get; set; }
    }
}
