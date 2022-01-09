using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Core.Repositorios;

namespace DevFreela.Application.Commands.CreateProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            project.Cancel();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
