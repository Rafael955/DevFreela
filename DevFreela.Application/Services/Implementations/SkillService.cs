using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<SkillViewModel> GetAll()
        {
            //Utilizando o Dapper para consulta
            using var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var script = "SELECT Id, Description FROM Skills";

            return sqlConnection.Query<SkillViewModel>(script).ToList();

            //var skills = _context.Skills;

            //var skillsViewModel = skills.Select(x => new SkillViewModel(x.Id, x.Description)).ToList();

            //return skillsViewModel;
        }
    }
}
