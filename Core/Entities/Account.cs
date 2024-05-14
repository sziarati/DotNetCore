namespace Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public Guid AccountGuid { get; set; }        
        public double Balance { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}