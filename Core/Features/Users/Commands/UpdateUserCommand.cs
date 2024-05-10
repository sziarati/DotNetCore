using MediatR;

namespace Core.Features.Users.Commands;

public record UpdateUserCommand(int Id, string Name, string Family, string Email) : IRequest<bool>;