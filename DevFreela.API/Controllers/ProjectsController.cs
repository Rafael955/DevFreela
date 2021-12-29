using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        //ex: api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            // listar todos os objetos
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        //ex: api/projects/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // return NotFound();
            // obter um objeto pelo id
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
                return BadRequest();

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
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        //ex: api/projects/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
