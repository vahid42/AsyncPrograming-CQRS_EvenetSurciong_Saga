using AccountApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [HttpPost("create")]
        public IActionResult CreateAccount([FromBody] CreateAccountRequest request)
        {
            _accountService.CreateAccount(request.AccountId, request.InitialBalance);
            return Ok();
        }

        [HttpPost("deposit")]
        public IActionResult Deposit([FromBody] DepositRequest request)
        {
            _accountService.Deposit(request.AccountId, request.Amount);
            return Ok();
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw([FromBody] WithdrawRequest request)
        {
            try
            {
                _accountService.Withdraw(request.AccountId, request.Amount);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{accountId}/balance")]
        public IActionResult GetBalance(Guid accountId)
        {
            var balance = _accountService.GetBalance(accountId);
            return Ok(balance);
        }
    }

    
}
