using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { } // Entity Framework

        public int Id { get; private set; }

    }
}
