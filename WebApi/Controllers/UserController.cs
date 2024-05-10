using Core.Features.Accounts.Commands;
using Core.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateAsync(CreateUserCommand input)
        {
            var addResult = await mediator.Send(input);
            return addResult > 0 ? Ok(addResult) : BadRequest("Creation failed.");
        }

        [HttpDelete("Delete/{userId}")]
        public async Task<ActionResult<bool>> DeleteAsync(DeleteUserCommand input)
        {
            var deleteResult = await mediator.Send(input);
            return deleteResult ? Ok() : NotFound("User Not Found.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult<bool>> UpdateAsync(UpdateUserCommand input)
        {
            var updateResult = await mediator.Send(input);
            return updateResult ? Ok(): NotFound("User Not Found.");
        }
    }
}