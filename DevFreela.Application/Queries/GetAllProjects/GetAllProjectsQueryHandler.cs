using Dapper;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly string _connectionString;

        public GetAllProjectsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var script = "SELECT Id, Title, CreatedAt FROM Projects";
       
            var listResult = await sqlConnection.QueryAsync<ProjectViewModel>(script);
            
            return listResult.ToList();

            //Usando o EF
            //var projects = _context.Projects;

            //var projectsViewModel = projects
            //    .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            //    .ToList();

            //return projectsViewModel;
        }
    }
}
