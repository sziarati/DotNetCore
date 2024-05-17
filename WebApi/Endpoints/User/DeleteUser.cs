using Core.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class DeleteUser : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("/DeleteUser/{userId}", async ([FromBody] DeleteUserCommand input, IMediator mediator) =>
        {
            var deleteResult = await mediator.Send(input);
            return deleteResult ? Results.Ok() : Results.NotFound("User Not Found.");
        })
        .WithName("DeleteUser")
        .WithTags("User");
    }
}
