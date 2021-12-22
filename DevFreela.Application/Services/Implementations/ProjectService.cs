using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost);

            _context.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.ProjectId, inputModel.UserId);

            _context.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == id);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == id);

            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _context.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == id);

            var projectDetailsViewModel = new ProjectDetailsViewModel
                (
                    project.Id,
                    project.Title,
                    project.Description,
                    project.TotalCost,
                    project.StartedAt,
                    project.FinishedAt
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == id);

            project.Start();
        }

        public void Update(UpdateProjectInputModel updateModel)
        {
            var project = _context.Projects.SingleOrDefault(x => x.Id == updateModel.Id);

            project.Update(updateModel.Title, updateModel.Description, updateModel.TotalCost);
        }
    }
}
