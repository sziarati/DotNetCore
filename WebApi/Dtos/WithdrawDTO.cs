namespace WebApi.Dtos
{
    public record WithdrawDTO(Guid FromAccount, Guid ToAccount, double Balance);
}