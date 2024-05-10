using Core.Enums;

namespace WebApi.Dtos
{
    public record AccountDto(double Balance, AccountType Type);
}