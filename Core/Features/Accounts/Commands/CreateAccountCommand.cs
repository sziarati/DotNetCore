using Core.Enums;
using MediatR;

namespace Core.Features.Accounts.Commands;

public record CreateAccountCommand(double Balance, int UserId, AccountType Type) : IRequest<Guid>;


