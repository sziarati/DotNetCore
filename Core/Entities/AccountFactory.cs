namespace Core.Entities
{
    public static class AccountFactory
    {
        public static Account Create(AccountType type, double balance)
        {
            Account account = type switch
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
            return account;
        }
    }
}