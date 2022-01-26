using DevFreela.API.Models;
using DevFreela.Application.Commands;
using DevFreela.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginUserCommand command)
        {
            //if (!ModelState.IsValid)
            //{
            //    var messages = ModelState
            //        .SelectMany(x => x.Value.Errors)
            //        .Select(e => e.ErrorMessage)
            //        .ToList();

            //    return BadRequest(messages);
            //}

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return NoContent();
        }
    }
}
