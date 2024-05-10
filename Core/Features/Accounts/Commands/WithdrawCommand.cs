using MediatR;

namespace Core.Features.Accounts.Commands;

public class WithdrawCommand : IRequest<bool>
{
    public Guid FromAccount { get; set; }
    public Guid ToAccount { get; set; }
    public double Balance { get; set; }
}


