using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<decimal> Create(Account account )
        {
            return await _AccountRepository.Add(account);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int accountId)
        {
            return await _AccountRepository.Delete(accountId);
        }

        [HttpPost]
        [Route("MoveMoney")]
        public async Task<bool> MoveMoney(MoveMoney moveMoney)
        {
            var accounts = new Tuple<Guid,Guid>(moveMoney.FromAccount, moveMoney.ToAccount);
            return await _AccountRepository.MoveMoney(accounts, moveMoney.Amount);
        }
    }
}