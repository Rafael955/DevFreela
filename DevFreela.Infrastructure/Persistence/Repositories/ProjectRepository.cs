﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositorios;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
