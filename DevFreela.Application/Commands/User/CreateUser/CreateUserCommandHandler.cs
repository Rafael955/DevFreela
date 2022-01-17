﻿using DevFreela.Core.Repositorios;
using Usuario = DevFreela.Core.Entities.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.User.CreateUser
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
            var user = new Usuario(request.FullName, request.Email, request.BirthDate);

            await _repository.CreateUserAsync(user);

            await _repository.SaveChangesAsync();

            return user.Id;
        }
    }
}
