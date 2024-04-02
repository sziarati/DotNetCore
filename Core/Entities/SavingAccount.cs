namespace Core.Entities
{
    public class SavingAccount : Account
    {
        public decimal MinimumBalance { get; private set; }
    }
}