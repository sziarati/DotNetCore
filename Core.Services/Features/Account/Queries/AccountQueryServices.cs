using Core.Dtos;
using Core.Features.Accounts.Queries;
using Core.Interfaces;

namespace Application.Features.Account.Queries;

public class AccountQueryServices(IAccountRepository accountRepository) : IAccountQueryServices
{
    public async Task<List<AccountInfo>> GetHistory(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        return await accountRepository.GetHistory(request.AccountGuid, request.ValidFrom, request.ValidTo);
    }
}
