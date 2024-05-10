using MediatR;

namespace Core.Features.Accounts.Commands;

public record UpdateAccountCommand(int Id, string Name, string Family, string Email) : IRequest<bool>;