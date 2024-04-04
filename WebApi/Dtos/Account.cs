using Core.Entities;

namespace WebApi.Dtos
{
    public record Account(double Balance, AccountType Type);
}