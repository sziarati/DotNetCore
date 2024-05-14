using Core.Dtos;
using Core.Entities;
using Core.Features.Accounts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Accounts.Repository
{
    public partial class AccountReader : IAccountReader
    {
        private readonly appDbContext _context;
        public AccountReader(appDbContext context)
        {
            _context = context;
        }
        public async Task<List<AccountInfo>> GetHistory(Guid accountGuid, DateTime validFrom, DateTime validTo)
        {
            var accountHistory = await _context.Accounts
                .TemporalAll()
                .Where(account => account.AccountGuid == accountGuid)
                .OrderBy(account => account.Created)
                .Select(account => new AccountInfo
                                            (account.AccountGuid,
                                             account.Balance,
                                             EF.Property<DateTime>(account, "ValidFrom"),
                                             EF.Property<DateTime>(account, "ValidTo")))
                .ToListAsync();

            return accountHistory;
        }
        public Account GetAccount(Guid accountGuid)
        {
            var account = _context.Accounts.Find(accountGuid);
            return account ?? new Account();
        }
    }
}