namespace AccountApi.Models
{
    public class Account
    {
        private List<object> _changes = new List<object>();


        public Guid Id { get; private set; }
        public decimal Balance { get; private set; }

        public Account(Guid id, decimal initialBalance)
        {
            ApplyChange(new AccountCreated(id, initialBalance));
        }

        public void Deposit(decimal amount)
        {
            ApplyChange(new MoneyDeposited(Id, amount));
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");
            ApplyChange(new MoneyWithdrawn(Id, amount));
        }

        public void ApplyChange(object @event)
        {
            _changes.Add(@event);
            When(@event);
        }

        private void When(object @event)
        {
            switch (@event)
            {
                case AccountCreated e:
                    Id = e.AccountId;
                    Balance = e.InitialBalance;
                    break;
                case MoneyDeposited e:
                    Balance += e.Amount;
                    break;
                case MoneyWithdrawn e:
                    Balance -= e.Amount;
                    break;
            }
        }

        public IEnumerable<object> GetChanges() => _changes;
    }
}
