using Core.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class CreateUser : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/CreateUser", async ([FromBody] CreateUserCommand input, IMediator mediator) =>
        {
            var addResult = await mediator.Send(input);
            return addResult > 0 ? Results.Ok(addResult) : Results.BadRequest("Creation failed.");
        })
        .WithName("CreateUser")
        .WithTags("User");
    }
}
