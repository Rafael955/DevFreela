using Dapper;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _context;

        public StartProjectCommandHandler(IConfiguration configuration, DevFreelaDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
            _context = context;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == request.Id);

            project.Start();

            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var script = $"UPDATE Projects SET Status = @status, StartedAt = @startedAt WHERE Id = @id";

            await sqlConnection.ExecuteAsync(script, new { status = project.Status, startedAt = project.StartedAt, id = project.Id });

            return Unit.Value;
        }
    }
}
