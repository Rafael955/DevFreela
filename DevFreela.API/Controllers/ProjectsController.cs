using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //ex: api/projects?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var _query = new GetAllProjectsQuery(query);
            // listar todos os objetos
            var projects = await _mediator.Send(_query);

            return Ok(projects);
        }

        //ex: api/projects/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // return NotFound();
            // obter um objeto pelo id
            var project = new GetProjectByIdQuery(id);

            var result = await _mediator.Send(project);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                    .SelectMany(x => x.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(messages);
            }

            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);
            // cadastro o objeto
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //ex: api/projects/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            // atualizo o objeto
            //_projectService.Update(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        //ex: api/projects/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Buscar, se não existir, retorna NotFound
            //var project = _projectService.GetById(id);

            //if (project == null) return NotFound();
            // Remover
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            //_projectService.Delete(id);

            return NoContent();
        }

        //ex: api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        //ex: api/projects/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var project = new StartProjectCommand(id);

            await _mediator.Send(project);

            //_projectService.Start(id);

            return NoContent();
        }

        //ex: api/projects/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var project = new FinishProjectCommand(id);

            await _mediator.Send(project);

            //_projectService.Finish(id);

            return NoContent();
        }
    }
}
