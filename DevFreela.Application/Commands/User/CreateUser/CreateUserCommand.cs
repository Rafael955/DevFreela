using DevFreela.Core.Repositorios;
using Usuario = DevFreela.Core.Entities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario(request.FullName, request.Email, request.BirthDate);

            await _repository.CreateUserAsync(user);

            await _repository.SaveChangesAsync();

            return user.Id;
        }
    }
}
