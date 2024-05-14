namespace Core.Entities
{
    public class User : IArchived
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Family { get; set; }
        public required NationalCode nationalCode { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Address? Address { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime EditDate { get; set; }

        //public DateTime BirthDate { get; set; }
        public bool IsArchived { get; set; } = false;
        public ICollection<Account>? accounts { get; set; }
    }
}