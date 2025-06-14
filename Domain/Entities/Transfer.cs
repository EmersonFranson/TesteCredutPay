namespace Domain.Entities
{
    public class Transfer
    {
        public Guid Id { get; set; }
        public Guid IdOriginUser { get; set; }
        public Guid IdDestinyUser { get; set; }
        public DateTime DtTransfer { get; set; }
        public decimal TransferValue { get; set; }
    }
}
