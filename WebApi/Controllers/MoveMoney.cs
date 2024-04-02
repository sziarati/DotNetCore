namespace WebApi.Controllers
{
    public class WithdrawDTO
    {
        public Guid FromAccount { get; set; }
        public Guid ToAccount { get; set; }
        public double Balance { get; set; }
    }
}