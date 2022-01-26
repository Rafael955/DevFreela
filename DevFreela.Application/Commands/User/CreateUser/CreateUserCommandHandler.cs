using DevFreela.Core.Repositorios;
using Usuario = DevFreela.Core.Entities.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Services;

namespace DevFreela.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario(request.FullName, request.Email, request.BirthDate, null, null);

            await _repository.CreateUserAsync(user);

            await _repository.SaveChangesAsync();

            return user.Id;
        }
    }
}
