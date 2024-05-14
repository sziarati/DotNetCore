using Core.Dtos;
using Core.Entities;
using Core.Features.Accounts.Interfaces;
using Core.Features.Accounts.Queries;

namespace Application.Features.Accounts.Queries;

public class AccountQueryServices(IAccountReader accountReader) : IAccountQueryServices
{
    public async Task<List<AccountInfo>> GetHistory(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        return await accountReader.GetHistory(request.AccountGuid, request.ValidFrom, request.ValidTo);
    }
    public Account GetAccount(Guid AccountGuid)
    {
        return accountReader.GetAccount(AccountGuid);
    }
}
