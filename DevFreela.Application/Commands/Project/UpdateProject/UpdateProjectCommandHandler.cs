using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;

        public UpdateProjectCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
