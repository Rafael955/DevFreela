using DevFreela.Application.Commands;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnsProjectId()
        {
            // ARRANGE
            var projectRepository = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo Testes",
                Description= "Descrição Daora",
                TotalCost = 50000,
                ClientId = 1,
                FreelancerId = 2
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            // ACT 
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // ASSERT
            Assert.True(id >= 0);

            projectRepository.Verify(x => x.AddAsync(It.IsAny<Project>()), Times.Once);

        }
    }
}
