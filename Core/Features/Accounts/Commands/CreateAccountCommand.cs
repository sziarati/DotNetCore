using Core.Enums;
using MediatR;

namespace Core.Features.Accounts.Commands;

public class CreateAccountCommand : IRequest<Guid>
{
    public double Balance { get; set; }
    public AccountType Type { get; set; }
}
