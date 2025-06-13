namespace Domain.Entities
{
    public  class User
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DtBirth { get; set; }
    }
}
