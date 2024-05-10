using MediatR;

namespace Core.Features.Users.Commands;

public record DeleteUserCommand(int userId) : IRequest<bool>;

