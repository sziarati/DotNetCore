using Core.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
public class UpdateUser : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/UpdateUser", async ([FromBody] UpdateUserCommand input, IMediator mediator) =>
        {
            var updateResult = await mediator.Send(input);
            return updateResult ? Results.Ok() : Results.NotFound("User Not Found.");
        })
        .WithName("UpdateUser")
        .WithTags("User");
    }
}