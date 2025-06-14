using Application.Entities.Transfers.Commmands.CreateTransfer;
using Application.Entities.Transfers.Queries.GetUserTransfers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransfer([FromBody] CreateTransferCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid transfer data.");
            }
            var transferId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTransferById), new { id = transferId }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransferById([FromQuery] GetUserTransfersQuery query)
        {
            var transfer = await _mediator.Send(query);
            if (transfer == null)
            {
                return NotFound();
            }
            return Ok(transfer);
        }
    }
}
