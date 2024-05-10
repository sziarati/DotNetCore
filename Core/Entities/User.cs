namespace Core.Entities
{
    public class User : IArchived
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime EditDate { get; set; }

        //public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public bool IsArchived { get; set; } = false;
    }
}