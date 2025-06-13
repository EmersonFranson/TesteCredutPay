namespace Domain.Entities
{
    public class Transfer
    {
        public Guid Id { get; set; }
        public Guid IdOriginWallet { get; set; }
        public Guid IdDestinyWallet { get; set; }
        public DateTime DtTransfer { get; set; }
        public decimal TransferValue { get; set; }
    }
}
