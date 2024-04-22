using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.UserFeatures.Commands;
using Project.Application.Features.UserFeatures.Queries;

namespace Projects.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create(CreateUserCommand commend)
        {
            return Ok(await _mediator.Send(commend));
        }
        [HttpGet("getAllUser")]
        public async Task<IActionResult> getAllCustomer()
        {
            return Ok(await _mediator.Send(new GetAllUserQuery()));
        }
        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> getCustomer(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery(id)));
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand(id)));
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserCommand commend)
        {
            if (id != commend.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(commend));
        }
    }
}

