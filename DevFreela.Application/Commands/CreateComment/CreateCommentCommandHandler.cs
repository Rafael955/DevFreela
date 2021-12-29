using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;

        public CreateCommentCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

            await _context.ProjectComments.AddAsync(comment);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
