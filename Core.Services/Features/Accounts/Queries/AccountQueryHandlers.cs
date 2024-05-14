using Core.Dtos;
using Core.Features.Accounts.Interfaces;
using Core.Features.Accounts.Queries;
using MediatR;

namespace Application.Features.Accounts.Queries;

public class AccountQueryHandlers(IAccountQueryServices accountQueryServices) :
    IRequestHandler<GetHistoryQuery, List<AccountInfo>>

{
    public async Task<List<AccountInfo>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        return await accountQueryServices.GetHistory(request, cancellationToken);
    }
}
