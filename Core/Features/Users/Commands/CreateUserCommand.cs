using MediatR;

namespace Core.Features.Users.Commands;

public record CreateUserCommand(string Name, string Family, string NationalCode, string Email, string MobileNumber) : IRequest<int>;

