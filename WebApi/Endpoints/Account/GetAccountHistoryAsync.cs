using Core.Features.Accounts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class GetAccountHistoryAsync : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/GetHistory", async ([FromBody] GetHistoryQuery input, IMediator mediator) =>
        {
            var historyResult = await mediator.Send(input);
            return Results.Ok(historyResult);
        })
        .WithName("GetHistory")
        .WithTags("Account");
    }
}