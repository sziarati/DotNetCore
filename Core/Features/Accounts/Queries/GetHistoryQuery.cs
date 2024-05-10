using Core.Dtos;
using MediatR;

namespace Core.Features.Accounts.Queries;

public class GetHistoryQuery : IRequest<List<AccountInfo>>
{
    public Guid AccountGuid { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}
