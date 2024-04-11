using Core.Entities;

namespace WebApi.Dtos
{
    public record AccountDto(double Balance, AccountType Type);
}