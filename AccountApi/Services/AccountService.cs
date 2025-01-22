using AccountApi.Models;

namespace AccountApi.Services
{
    public class AccountService
    {
        private readonly List<object> _eventStore = new List<object>();

        public void CreateAccount(Guid accountId, decimal initialBalance)
        {
            var account = new Account(accountId, initialBalance);
            _eventStore.AddRange(account.GetChanges()); // ذخیره تغییرات  
        }

        public void Deposit(Guid accountId, decimal amount)
        {
            var account = LoadAccount(accountId);
            account.Deposit(amount);
            _eventStore.AddRange(account.GetChanges());
        }

        public void Withdraw(Guid accountId, decimal amount)
        {
            var account = LoadAccount(accountId);
            account.Withdraw(amount);
            _eventStore.AddRange(account.GetChanges());
        }

        public Account LoadAccount(Guid accountId)
        {
            var events = _eventStore.Where(e => e is AccountCreated || e is MoneyDeposited || e is MoneyWithdrawn);
            var account = new Account(accountId, 0); // مقدار اولیه  
            foreach (var ev in events)
            {
                account.ApplyChange(ev);
            }
            return account;
        }

        public decimal GetBalance(Guid accountId)
        {
            var account = LoadAccount(accountId);
            return account.Balance;
        }
    }
}
