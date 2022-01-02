using Dapper;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly string _connectionString;

        public ProjectService(DevFreelaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        //public int Create(NewProjectInputModel inputModel)
        //{
        //    var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost);

        //    _context.Projects.Add(project);

        //    _context.SaveChanges();

        //    return project.Id;
        //}

        //public void CreateComment(CreateCommentInputModel inputModel)
        //{
        //    var comment = new ProjectComment(inputModel.Content, inputModel.ProjectId, inputModel.UserId);

        //    _context.ProjectComments.Add(comment);

        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var project = _context.Projects.SingleOrDefault(x => x.Id == id);

        //    project.Cancel();

        //    _context.SaveChanges();
        //}

        //public void Finish(int id)
        //{
        //    var project = _context.Projects.SingleOrDefault(x => x.Id == id);

        //    project.Finish();

        //    _context.SaveChanges();
        //}

        //public List<ProjectViewModel> GetAll(string query)
        //{

        //    using var sqlConnection = new SqlConnection(_connectionString);
        //    sqlConnection.Open();

        //    var script = "SELECT Id, Title, CreatedAt FROM Projects";

        //    return sqlConnection.Query<ProjectViewModel>(script).ToList();

        //    //var projects = _context.Projects;

        //    //var projectsViewModel = projects
        //    //    .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
        //    //    .ToList();

        //    //return projectsViewModel;
        //}

        //public ProjectDetailsViewModel GetById(int id)
        //{
        //    var project = _context.Projects
        //        .Include(p => p.Client)
        //        .Include(p => p.Freelancer)
        //        .SingleOrDefault(x => x.Id == id);

        //    var projectDetailsViewModel = new ProjectDetailsViewModel
        //        (
        //            project.Id,
        //            project.Title,
        //            project.Description,
        //            project.TotalCost,
        //            project.StartedAt,
        //            project.FinishedAt,
        //            project.Client.FullName,
        //            project.Freelancer.FullName
        //        );

        //    return projectDetailsViewModel;
        //}

        //public void Start(int id)
        //{
        //    var project = _context.Projects.SingleOrDefault(x => x.Id == id);

        //    project.Start();

        //    //_context.SaveChanges();

        //    using var sqlConnection = new SqlConnection(_connectionString);
        //    sqlConnection.Open();

        //    var script = $"UPDATE Projects SET Status = @status, StartedAt = @startedAt WHERE Id = @id";

        //    sqlConnection.Execute(script, new { status = project.Status, startedAt = project.StartedAt, id = project.Id });
        //}

        //public void Update(UpdateProjectInputModel updateModel)
        //{
        //    var project = _context.Projects.SingleOrDefault(x => x.Id == updateModel.Id);

        //    project.Update(updateModel.Title, updateModel.Description, updateModel.TotalCost);

        //    _context.SaveChanges();
        //}
    }
}
