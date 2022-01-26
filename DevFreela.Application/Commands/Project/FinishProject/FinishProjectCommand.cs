using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Commands
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public FinishProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
