namespace Core.Dtos;
public class AccountInfo
{
    public AccountInfo(Guid AccountGuid, double Balance, DateTime ValidFrom, DateTime ValidTo)
    {
        this.AccountGuid = AccountGuid;
        this.Balance = Balance;
        this.ValidFrom = ValidFrom;
        this.ValidTo = ValidTo;
    }

    public Guid AccountGuid { get; }
    public double Balance { get; }
    public DateTime ValidFrom { get; }
    public DateTime ValidTo { get; }
}


