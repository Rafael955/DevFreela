using DevFreela.Application.Queries;
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

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {

        // Usando padrão de nomenclatura GIVEN_WHEN_THEN para nome do método de testes
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // ARRANGE
            var projects = new List<Project>
            {
                new Project("Nome Do Teste 1", "Descricao De Teste 1", 1, 2, 10000),
                new Project("Nome Do Teste 2", "Descricao De Teste 2", 1, 2, 20000),
                new Project("Nome Do Teste 3", "Descricao De Teste 3", 1, 2, 30000),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(x => x.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // ACT
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // ASSERT
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(x => x.GetAllAsync().Result, Times.Once);
        }
    }
}
