using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.CreateProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;

        public DeleteProjectCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == request.Id);

            project.Cancel();

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
