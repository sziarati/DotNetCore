using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("Create")]    
        public async Task<ActionResult<decimal>> CreateAsync(AccountDto accountInfo)
        {
            var accountToAdd = AccountFactory.Create(accountInfo.Type, accountInfo.Balance);
            var addResult = await _accountRepository.Add(accountToAdd);
            return addResult > 0 ? Ok(addResult) : BadRequest("Creation failed.");
        }

        [HttpDelete("Delete/{accountId}")]
        public async Task<IActionResult> DeleteAsync(int accountId)
        {
            var deleteResult = await _accountRepository.Delete(accountId);
            return deleteResult ? Ok() : NotFound("Account not found.");
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> WithdrawAsync(WithdrawDto input)
        {
            var accounts = Tuple.Create(input.FromAccount, input.ToAccount);

            var moveMoneyResult = await _accountRepository.MoveMoney(accounts, input.Balance);
            return moveMoneyResult? Ok() : BadRequest();
        }

        [HttpGet("History")]
        public async Task<ActionResult<List<AccountInfo>>> GetAccountHistoryAsync(AccountHistoryDto input)
        {
            var historyResult = await _accountRepository.GetHistory(input.AccountGuid, input.ValidFrom, input.ValidTo);
            return Ok(historyResult);
        }
    }    
}