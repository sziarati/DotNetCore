using Core.Enums;

namespace Core.Entities
{
    public static class AccountFactory
    {
        public static Account Create(AccountType type, double balance, int userId)
        {
            Account account = type switch
            {
                AccountType.CHECKING_ACCOUNT => new CheckingAccount
                {
                    Balance = balance,
                    UserId = userId
                },

                AccountType.SAVINGS_ACCOUNT => new SavingAccount
                {
                    Balance = balance,
                    UserId = userId
                }
            };
            return account;
        }
    }
}