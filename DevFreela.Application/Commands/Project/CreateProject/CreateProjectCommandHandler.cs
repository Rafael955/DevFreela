using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands
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
