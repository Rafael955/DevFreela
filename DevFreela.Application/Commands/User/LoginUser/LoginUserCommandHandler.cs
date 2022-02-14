using DevFreela.Core.Repositories;
using Usuario = DevFreela.Core.Entities.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Services;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            // Se não existir, erro no login
            if (user == null)
                return null;

            // Se existir, gero o token usando os dados do usuário
            var accessToken = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, accessToken);

            return loginUserViewModel;
        }
    }
}
