using Application.Entities.Wallets.Commands.AddWalletBalance.AddBalance;
using Application.Entities.Wallets.Commands.AddWalletBalance.AddWallet;
using Application.Entities.Wallets.Queries.GetWalletBalance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromBody] AddBalanceWalletCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid wallet data.");
            }
            var walletId = await _mediator.Send(command);
            return Ok(walletId);
        }

        [HttpPut]
        public async Task<IActionResult> AddBalance([FromBody] PutWalletBalanceCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWallet([FromQuery] GetWalletBalanceQuery query)
        {
            var wallet = await _mediator.Send(query);

            return Ok(wallet);
        }
    }
}
