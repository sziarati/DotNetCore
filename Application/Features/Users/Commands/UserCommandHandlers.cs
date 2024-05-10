using Core.Entities;
using Core.Features.Users.Commands;
using Core.Interfaces;
using MediatR;

namespace Core.Services.Features.Users.Commands
{
    public class UserCommandHandlers : IRequestHandler<UpdateUserCommand, bool>
    {
        public Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class UserCommandServices(IUserRepository userRepository) : IUserCommandServices
    {
        public async Task<bool> UpdateUser(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
                EditDate = DateTime.Now,
                Name = request.Name,
                Family = request.Family,
                Email = request.Email,
                IsArchived = false
            };

            return await userRepository.Update(user);
        }
    }

    public interface IUserCommandServices
    {
        Task<bool> UpdateUser(UpdateUserCommand request, CancellationToken cancellationToken);

    }
}
