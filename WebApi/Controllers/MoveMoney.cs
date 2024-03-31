namespace WebApi.Controllers
{
    public class MoveMoney
    {
        public Guid FromAccount { get; set; }
        public Guid ToAccount { get; set; }
        public double Amount { get; set; }
    }
}