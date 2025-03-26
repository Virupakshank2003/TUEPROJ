using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TUEPROJ.Application.Commands;
using TUEPROJ.Application.Queries;
using TUEPROJ.Domain;

namespace TUEPROJ.Presentation
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("person")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            //if (command == null)
            //{
            //    return BadRequest("Invalid User Data");
            //}

            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]int page = 1, [FromQuery]int pageSize=10, [FromQuery] string? searchTerm = null)
        {
            var response = await _mediator.Send(new GetUsersQuery(page,pageSize,searchTerm));
            return Ok(response);

        }

        [HttpPut("{id}/toggle-status")]
        public async Task<IActionResult> ToggleUserStatus(int id)
        {
            var result = await _mediator.Send(new ToggleStatusCommand(id));

           return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteUser(int id)
        {
            var result =await _mediator.Send(new DeleteUserCommand(id));
            return Ok(result);
        }

        [HttpPost("{id}/Activate")]
        public async Task<IActionResult>ActivateUser(int id)
        {
            var result=await _mediator.Send(new ActivateUserCommand(id));
            return Ok(result);
        }

        [HttpPost("{id}/Deactivate")]
        public async Task<IActionResult> DeactivateUser(int id)
        {
            var result = await _mediator.Send(new DeactivateUserCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult>GetUserbyId(int id)
        {
            var result=await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }





    }
}
 