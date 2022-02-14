using DevFreela.Core.Repositories;
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
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new Usuario(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _repository.CreateUserAsync(user);

            await _repository.SaveChangesAsync();

            return user.Id;
        }
    }
}
