namespace AccountApi.Models
{
    public class AccountCreated
    {
        public Guid AccountId { get; }
        public decimal InitialBalance { get; }

        public AccountCreated(Guid accountId, decimal initialBalance)
        {
            AccountId = accountId;
            InitialBalance = initialBalance;
        }
    }
    //واریز
    public class MoneyDeposited
    {
        public Guid AccountId { get; }
        public decimal Amount { get; }

        public MoneyDeposited(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
    //برداشت
    public class MoneyWithdrawn
    {
        public Guid AccountId { get; }
        public decimal Amount { get; }

        public MoneyWithdrawn(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
