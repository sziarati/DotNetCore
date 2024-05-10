using Core.Dtos;
using Core.Features.Accounts.Commands;
using Core.Features.Accounts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Create")]    
        public async Task<ActionResult<Guid>> CreateAsync(CreateAccountCommand input)
        {
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
        public async Task<IActionResult> WithdrawAsync(WithdrawCommand input)
        {

            var moveMoneyResult = await mediator.Send(input);
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