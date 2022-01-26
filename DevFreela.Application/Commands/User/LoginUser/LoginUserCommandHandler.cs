using DevFreela.Core.Repositorios;
using Usuario = DevFreela.Core.Entities.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Services;

namespace DevFreela.Application.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, int>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
        }

        public async Task<int> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new Usuario(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _repository.CreateUserAsync(user);

            await _repository.SaveChangesAsync();

            return user.Id;
        }
    }
}
