using Core.Features.Accounts.Commands;
using Core.Features.Accounts.Interfaces;
using MediatR;

namespace Application.Features.Accounts.Commands;

public class AccountCommandHandlers(IAccountCommandServices accountCommandServices) :
    IRequestHandler<CreateAccountCommand, Guid>,
    IRequestHandler<WithdrawCommand, bool>,
    IRequestHandler<DeleteAccountCommand, bool>

{
    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        return await accountCommandServices.CreateAccount(request, cancellationToken);
    }

    public async Task<bool> Handle(WithdrawCommand request, CancellationToken cancellationToken)
    {
        return await accountCommandServices.WithDraw(request, cancellationToken);
    }

    public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        return await accountCommandServices.DeleteAccount(request, cancellationToken);
    }
}
