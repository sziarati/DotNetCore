using Common.Bases;
using Core.Dtos;
using Core.Features.Accounts.Queries;

namespace Core.Features.Accounts.Interfaces;

public interface IAccountQueryServices : ITransient
{
    Task<List<AccountInfo>> GetHistory(GetHistoryQuery request, CancellationToken cancellationToken);
}
