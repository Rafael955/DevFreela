using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;

        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        //ex: api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            // listar todos os objetos
            return Ok();
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
        public IActionResult Post([FromBody] CreateProjectModel projectModel)
        {
            if (projectModel.Title.Length > 50)
                return BadRequest();

            // cadastro o objeto
            return CreatedAtAction(nameof(GetById), new { id = projectModel.Id }, projectModel);
        }

        //ex: api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel projectModel)
        {
            if (projectModel.Description.Length > 200)
                return BadRequest();

            // atualizo o objeto
            return NoContent();
        }

        //ex: api/projects/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar, se não existir, retorna NotFound

            // Remover

            return NoContent();
        }

        //ex: api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentModel commentModel)
        {
            return NoContent();
        }

        //ex: api/projects/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        //ex: api/projects/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
