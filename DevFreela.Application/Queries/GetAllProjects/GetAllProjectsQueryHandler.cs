using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositorios;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            //_connectionString = configuration.GetConnectionString("DevFreelaCs");
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            // EF com padrão repository
            var projects = await _repository.GetAllAsync();

            if(!string.IsNullOrEmpty(request.Query))
                projects = new List<Project>(projects.Where(x => x.Title.Contains(request.Query)));

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;

            // Dapper
            //using var sqlConnection = new SqlConnection(_connectionString);

            //sqlConnection.Open();

            //var script = "SELECT Id, Title, CreatedAt FROM Projects";

            //var listResult = await sqlConnection.QueryAsync<ProjectViewModel>(script);

            //return listResult.ToList();

            //Usando o EF
            //var projects = _context.Projects;

            //var projectsViewModel = projects
            //    .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            //    .ToList();

            //return projectsViewModel;
        }
    }
}
