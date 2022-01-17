﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
    }
}