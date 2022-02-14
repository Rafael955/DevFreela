using Dapper;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            project.Start();

            await _repository.StartAsync(project);

            return Unit.Value;
        }
    }
}
