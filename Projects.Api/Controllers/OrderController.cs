using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.DeliveryAddressFeatures.Commands;
using Project.Application.Features.DeliveryAddressFeatures.Queries;
using Project.Application.Features.OrderFeatures.Commands;
using Project.Application.Features.OrderFeatures.Queries;

namespace Projects.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Create(CreateOrderCommand commend)
        {
            return Ok(await _mediator.Send(commend));
        }
        [HttpGet("getAllOrder")]
        public async Task<IActionResult> getAllCustomer()
        {
            return Ok(await _mediator.Send(new GetAllOrderQuery()));
        }
        [HttpGet("getOrder/{id}")]
        public async Task<IActionResult> getCustomer(Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery(id)));
        }
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteOrderCommand(id)));
        }
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateOrderCommand commend)
        {
            if (id != commend.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(commend));
        }
    }
}
