using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
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
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
                return BadRequest();

            var id = _projectService.Create(inputModel);

            // cadastro o objeto
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        //ex: api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
                return BadRequest();

            // atualizo o objeto
            _projectService.Update(inputModel);

            return NoContent();
        }

        //ex: api/projects/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar, se não existir, retorna NotFound
            //var project = _projectService.GetById(id);

            //if (project == null) return NotFound();
            // Remover
            _projectService.Delete(id);

            return NoContent();
        }

        //ex: api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

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
