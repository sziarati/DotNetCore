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
        private readonly IAccountRepository _AccountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _AccountRepository = accountRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<decimal> Create([FromHeader] AccountType type, double balance )
        {
            Core.Entities.Account accountToAdd = type switch
            {
                AccountType.CHECKING_ACCOUNT => new CheckingAccount
                {
                    Balance = balance,                    
                },

                AccountType.SAVINGS_ACCOUNT => new SavingAccount
                {
                    Balance = balance,
                }
            };
            
            return await _AccountRepository.Add(accountToAdd);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int accountId)
        {
            return await _AccountRepository.Delete(accountId);
        }

        [HttpPost]
        [Route("Withdraw")]
        public async Task<bool> Withdraw(WithdrawDTO input)
        {
            var accounts = new Tuple<Guid,Guid>(input.FromAccount, input.ToAccount);
            return await _AccountRepository.MoveMoney(accounts, input.Balance);
        }
    }    
}