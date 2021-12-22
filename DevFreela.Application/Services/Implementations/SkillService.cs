using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;

        public SkillService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _context.Skills;

            var skillsViewModel = skills.Select(x => new SkillViewModel(x.Id, x.Description)).ToList();

            return skillsViewModel;
        }
    }
}
