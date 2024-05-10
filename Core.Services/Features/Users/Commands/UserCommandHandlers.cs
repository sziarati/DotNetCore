using Core.Features.Users.Commands;
using Core.Interfaces;
using MediatR;

namespace Core.Services.Features.Users.Commands;


public class UserCommandHandlers(IUserCommandServices userCommandServices) : 
    IRequestHandler<UpdateUserCommand, bool>,
    IRequestHandler<CreateUserCommand, int>,
    IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await userCommandServices.UpdateUser(request, cancellationToken);
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await userCommandServices.CreateUser(request, cancellationToken);
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
       return await userCommandServices.DeleteUser(request, cancellationToken);
    }
}
