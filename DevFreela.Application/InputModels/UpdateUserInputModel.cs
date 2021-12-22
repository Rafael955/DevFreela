using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public int Id { get; private set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
