using MediatR;

namespace Core.Features.Accounts.Commands;

public class DeleteAccountCommand : IRequest<bool>
{
    public int AccountId { get; set; }
} 

