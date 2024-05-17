using Core.Features.Accounts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class CreateAccount : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/CreateAccount", async ([FromBody] CreateAccountCommand input, IMediator mediator) =>
        {
            var addResult = await mediator.Send(input);
            return addResult == Guid.Empty ? Results.BadRequest("Creation failed.") : Results.Ok(addResult);
        })
        .WithName("CreateAccount")
        .WithTags("Account");
    }
}