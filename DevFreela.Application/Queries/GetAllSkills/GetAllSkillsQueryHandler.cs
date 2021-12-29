using Dapper;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly string _connectionString;

        public GetAllSkillsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var script = "SELECT Id, Description FROM Skills";
            
            var queryResult = await sqlConnection.QueryAsync<SkillViewModel>(script);

            return queryResult.ToList();

            //Consulta com Entity Framework Core
            //var skills = _context.Skills;

            //var skillsViewModel = skills.Select(x => new SkillViewModel(x.Id, x.Description)).ToList();

            //return skillsViewModel;
        }
    }
}
