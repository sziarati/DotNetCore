using Common.Bases;
using Core.Features.Users.Commands;

namespace Core.Features.Users.Interfaces;
public interface IUserCommandServices : ITransient
{
    Task<bool> UpdateUser(UpdateUserCommand request, CancellationToken cancellationToken);
    Task<int> CreateUser(CreateUserCommand request, CancellationToken cancellationToken);
    Task<bool> DeleteUser(DeleteUserCommand request, CancellationToken cancellationToken);


}
