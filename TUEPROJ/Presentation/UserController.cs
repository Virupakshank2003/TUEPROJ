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
            if (command == null)
            {
                return BadRequest("Invalid User Data");
            }

            var userId = await _mediator.Send(command);
            return Ok(new { Message = "User Successfully Created", UserId = userId });
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllQuery());
            return Ok(users);

        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery]string searchTerm)
        {
            var users  = await _mediator.Send(new SearchUserQuery(searchTerm));
            return Ok(users);
        }
    }
}
