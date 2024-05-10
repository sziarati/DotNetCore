using Core.Dtos;
using Core.Features.Accounts.Queries;
using Core.Interfaces;
using MediatR;

namespace Application.Features.Account.Queries;

public class AccountQueryHandlers(IAccountQueryServices accountQueryServices) :
    IRequestHandler<GetHistoryQuery, List<AccountInfo>>

{
    public async Task<List<AccountInfo>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        return await accountQueryServices.GetHistory(request, cancellationToken);
    }
}
