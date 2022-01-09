using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositorios;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task StartAsync(Project project)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var script = "UPDATE Projects SET Status = @status, StartedAt = @startedAt WHERE Id = @id";

            await sqlConnection.ExecuteAsync(script, new { status = project.Status, startedAt = project.StartedAt, id = project.Id });
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectComment comment)
        {
            await _context.ProjectComments.AddAsync(comment);
        }
    }
}
