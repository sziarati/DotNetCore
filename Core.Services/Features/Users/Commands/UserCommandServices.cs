using Core.Entities;
using Core.Features.Users.Commands;
using Core.Features.Users.Interfaces;

namespace Application.Features.Users.Commands;

public class UserCommandServices(IUserRepository userRepository) : IUserCommandServices
{
    public async Task<int> CreateUser(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            CreateDate = DateTime.Now,
            Name = request.Name,
            Family = request.Family,
            nationalCode = new NationalCode { Code = request.NationalCode },
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            IsArchived = false
        };

        return await userRepository.Add(user);
    }

    public async Task<bool> DeleteUser(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await userRepository.Delete(request.userId);
    }

    public async Task<bool> UpdateUser(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = request.Id,
            EditDate = DateTime.Now,
            Name = request.Name,
            Family = request.Family,
            nationalCode = new NationalCode { Code = request.NationalCode },
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            IsArchived = false
        };

        return await userRepository.Update(user);
    }
}
