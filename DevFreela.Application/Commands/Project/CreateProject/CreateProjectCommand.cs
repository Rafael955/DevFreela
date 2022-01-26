using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        public int FreelancerId { get; set; }

        public decimal TotalCost { get; set; }
    }
}
