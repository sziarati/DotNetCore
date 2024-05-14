using Azure.Core;
using Core.Dtos;
using Core.Features.Accounts.Commands;
using Core.Features.Accounts.Interfaces;
using Core.Features.Accounts.Queries;
using Core.Features.Notification;
using Infra.Accounts.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IMediator mediator/*, INotificationService notificationService*/, IAccountReader accountReader) : ControllerBase
    {
        [HttpPost("Create")]    
        public async Task<ActionResult<Guid>> CreateAsync(CreateAccountCommand input)
        {
            //var x = new CreateAccountCommand(input.Balance, Core.Enums.AccountType.SAVINGS_ACCOUNT, input.UserId);

            var addResult = await mediator.Send(input);
            return addResult != Guid.Empty ? Ok(addResult) : BadRequest("Creation failed.");
        }

        [HttpDelete("Delete/{accountId}")]
        public async Task<IActionResult> DeleteAsync(DeleteAccountCommand input)
        {
            var deleteResult = await mediator.Send(input);
            return deleteResult ? Ok() : NotFound("Account not found.");
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> WithdrawAsync(WithdrawDto input)
        {
            var withdrawCommand = new WithdrawCommand
            {
                Balance = input.Balance,
                FromAccount = input.FromAccount,
                ToAccount = input.ToAccount
            };

            var moveMoneyResult = await mediator.Send(withdrawCommand);

            var account = accountReader.GetAccount(input.FromAccount);

            //if (input.Types?.Count > 0)
            //{
            //    var notificationClass = new NotificationClass
            //    {
            //        Subject = $"Dear {account.user.Name}",
            //        RecieverEmail = account.user.Email,
            //        RecieverMobileNumber = account.user.MobileNumber,
            //        Types = input.Types
            //    };

            //    notificationClass.Message = moveMoneyResult ? 
            //                                $" {input.Balance}$ Moved Successfully from {input.FromAccount} to {input.ToAccount}." :
            //                                $" {input.Balance}$ did not Move from {input.FromAccount} to {input.ToAccount}. It will Return to your account in less than 72 hours." ;

            //    await notificationService.SendNotification(notificationClass);
            //}

            return moveMoneyResult ? Ok() : BadRequest();
        }

        [HttpGet("History")]
        public async Task<ActionResult<List<AccountInfo>>> GetAccountHistoryAsync(GetHistoryQuery input)
        {
            var historyResult = await mediator.Send(input);
            return Ok(historyResult);
        }
    }    
}