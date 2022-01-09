using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositorios
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}
