using DevFreela.Core.Entities;
using DevFreela.Core.Repositorios;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);

            await _repository.AddAsync(project);

            await _repository.SaveChangesAsync();

            return project.Id;
        }
    }
}
