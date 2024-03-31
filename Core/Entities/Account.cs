namespace Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public Guid AcountGuid { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        // Other properties like Date, Description, etc.
    }
}