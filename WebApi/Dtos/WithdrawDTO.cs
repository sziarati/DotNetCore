namespace WebApi.Dtos;
public record WithdrawDto(Guid FromAccount, Guid ToAccount, double Balance);
