namespace AccountApi.Controllers
{
    public class CreateAccountRequest
    {
        public Guid AccountId { get; set; }
        public decimal InitialBalance { get; set; }
    }

    public class DepositRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public class WithdrawRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }

}
