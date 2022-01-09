using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositorios
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task AddAsync(Project project);

        Task AddCommentAsync(ProjectComment comment);

        Task StartAsync(Project project);

        Task SaveChangesAsync();
    }
}
