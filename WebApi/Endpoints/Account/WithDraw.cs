using Core.Features.Accounts.Commands;
using Core.Features.Accounts.Interfaces;
using Core.Features.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

public class WithDraw : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Withdraw", async ([FromBody] WithdrawDto input, IMediator mediator, IAccountReader accountReader, INotificationService notificationService) =>
        {
            var withdrawCommand = new WithdrawCommand
            {
                Balance = input.Balance,
                FromAccount = input.FromAccount,
                ToAccount = input.ToAccount
            };

            var moveMoneyResult = await mediator.Send(withdrawCommand);

            var account = accountReader.GetAccount(input.FromAccount);

            if (input.Types?.Count > 0)
            {
                var notificationClass = new NotificationClass
                {
                    Subject = $"Dear {account.User.Name}",
                    RecieverEmail = account.User.Email,
                    RecieverMobileNumber = account.User.MobileNumber,
                    Types = input.Types
                };

                notificationClass.Message = moveMoneyResult ?
                                            $" {input.Balance}$ Moved Successfully from {input.FromAccount} to {input.ToAccount}." :
                                            $" {input.Balance}$ did not Move from {input.FromAccount} to {input.ToAccount}. It will Return to your account in less than 72 hours.";

                await notificationService.SendNotification(notificationClass);
            }

            return moveMoneyResult ? Results.Ok() : Results.BadRequest();
        })
        .WithName("WithDraw")
        .WithTags("Account");
    }
}