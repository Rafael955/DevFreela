﻿using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
