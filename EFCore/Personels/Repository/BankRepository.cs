using Core.Entities;
using Core.Interfaces;

namespace Infra.Personels.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly appDbContext _context;
        public BankRepository(appDbContext context)
        {
            _context = context;
        }
        public async Task<bool> MoveAmount(Tuple<Guid, double> from, Tuple<Guid, double> to)
        {
            const int maxRetryCount = 3; // Maximum number of retry attempts
            int retryCounter = 0;

            while (retryCounter < maxRetryCount)
            {
                try
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        // Perform an initial banking transaction
                        _context.Accounts.Add(new Account { Amount = from.Item2 });
                        _context.SaveChanges();

                        // Create a savepoint here
                        transaction.CreateSavepoint("MoveAmountSavepoint");

                        // Perform another transaction
                        _context.Accounts.Add(new Account { Amount = to.Item2 });
                        _context.SaveChanges();

                        // Commit the transaction
                        transaction.Commit();

                        // If transaction is successful, break out of the loop
                        break;
                    }
                }
                catch (Exception ex)
                {
                    retryCounter++;
                    Console.WriteLine($"An error occurred: {ex.Message}. Attempting retry {retryCounter}/{maxRetryCount}.");


                    if (retryCounter >= maxRetryCount)
                    {
                        Console.WriteLine("Maximum retry attempts reached. Transaction failed.");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}