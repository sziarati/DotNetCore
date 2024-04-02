namespace Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public Guid AcountGuid { get; set; }        
        public double Balance { get; set; }
        public DateTime Created { get; set; }
    }
}