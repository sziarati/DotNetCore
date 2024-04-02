namespace Core.Entities
{
    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; private set; }
    }
}