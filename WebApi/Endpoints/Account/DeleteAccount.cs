using Core.Features.Accounts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class DeleteAccount : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("/DeleteAccount/{accountId}", async ([FromBody] DeleteAccountCommand input, IMediator mediator) =>
        {
            var deleteResult = await mediator.Send(input);
            return deleteResult ? Results.Ok() : Results.NotFound("Account not found.");
        })
        .WithName("DeleteAccount")
        .WithTags("Account");
    }
}