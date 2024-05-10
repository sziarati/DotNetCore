using Common.Bases;
using Core.Features.Accounts.Commands;

namespace Core.Interfaces;

public interface IAccountCommandServices:ITransient
{
    Task<Guid> CreateAccount(CreateAccountCommand request, CancellationToken cancellationToken);
    Task<bool> DeleteAccount(DeleteAccountCommand request, CancellationToken cancellationToken);
    Task<bool> WithDraw(WithdrawCommand request, CancellationToken cancellationToken);

}
