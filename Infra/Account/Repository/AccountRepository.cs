using Core.Dtos;
using Core.Entities;
using Core.Features.Accounts.Interfaces;
using Core.Features.Notification;
using Infra.Notification;
using Microsoft.EntityFrameworkCore;

namespace Infra.Accounts.Repository
{
    public partial class AccountRepository : IAccountRepository
    {
        private readonly string MoveMoneySavepointName = "MoveMoneySavepoint";
        private readonly appDbContext _context;
        public AccountRepository(appDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Add(Account account)
        {
            account.Created = DateTime.Now;
            account.AccountGuid = Guid.NewGuid();
            _context.Accounts.Add(account);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? account.AccountGuid : Guid.Empty;
        }
        public async Task<bool> Update(Account account)
        {
            var accountFounded = _context.Accounts.FirstOrDefault(p => p.AccountGuid == account.AccountGuid);

            if (accountFounded == null)
                return false;

            accountFounded.Balance += account.Balance;
            _context.Entry(accountFounded).State = EntityState.Modified;

            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }
        public async Task<bool> Delete(int Id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.Id == Id);
            if (account is null)
                return false;

            _context.Accounts.Remove(account);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> MoveMoney(Tuple<Guid, Guid> account, double balance)
        {
            const int maxRetryCount = 3; // Maximum number of retry attempts
            int retryCounter = 0;

            var fromAccount = new Account
            {
                AccountGuid = account.Item1,
                Balance = balance
            };

            var toAccount = new Account
            {
                AccountGuid = account.Item2,
                Balance = balance
            };

            var transaction = await _context.Database.BeginTransactionAsync();
            while (retryCounter < maxRetryCount)
            {
                try
                {
                    // Perform an initial banking transaction
                    var fromAccountResult = await Update(fromAccount);
                    if (!fromAccountResult)
                    {
                        await transaction.RollbackAsync();
                    }

                    // Create a savepoint here
                    await transaction.CreateSavepointAsync(MoveMoneySavepointName);

                    // Perform another transaction
                    var toAccountResult = await Update(toAccount);
                    if (!toAccountResult)
                    {
                        throw new Exception();
                    }

                    // Commit the transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    retryCounter++;

                    if (retryCounter >= maxRetryCount)
                    {
                        await transaction.ReleaseSavepointAsync(MoveMoneySavepointName);
                        await transaction.RollbackAsync();
                        return false;
                    }

                    await transaction.RollbackToSavepointAsync(MoveMoneySavepointName);
                    // Perform another transaction
                    
                    var toAccountResult = await Update(toAccount);
                    if (!toAccountResult)
                    {
                        throw new Exception();
                    }

                    // Commit the transaction
                    await transaction.CommitAsync();
                }

                // If transaction is successful, break out of the loop
                break;
            }            
            return true;
        }
    }
}