using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entidades
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { } // Entity Framework

        public int Id { get; private set; }
    }
}
