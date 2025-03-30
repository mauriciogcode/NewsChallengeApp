using Moq;
using NewsApi.Application.Commands;
using NewsApi.Application.Queries;
using NewsApi.Domain.Entities;
using NewsApi.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    public class NewsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly NewsController _controller;

        public NewsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new NewsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WhenNewsListIsFound()
        {
            // Arrange
            var newsList = new List<News> { new News { Id = 1, Title = "Test News" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetNewsListQuery>(), default))
                         .ReturnsAsync(newsList);

            // Act
            var result = await _controller.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<News>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<News>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnsNoContent_WhenNewsListIsEmpty()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetNewsListQuery>(), default))
                         .ReturnsAsync((List<News>)null);

            // Act
            var result = await _controller.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<News>>>(result);
            var noContentResult = Assert.IsType<NoContentResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WhenNewsIsFound()
        {
            // Arrange
            var newsItem = new News { Id = 1, Title = "Test News" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetNewsByIdQuery>(), default))
                         .ReturnsAsync(newsItem);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<News>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<News>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenNewsIsNotFound()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetNewsByIdQuery>(), default))
                         .ReturnsAsync((News)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<News>>(result);
            var notFoundResult = Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult_WhenNewsIsCreated()
        {
            // Arrange
            var command = new CreateNewsCommand { Title = "New News" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateNewsCommand>(), default))
                         .ReturnsAsync(1);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var actionResult = Assert.IsType<ActionResult<int>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            Assert.Equal(1, createdResult.RouteValues["id"]);
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenNewsIsUpdated()
        {
            // Arrange
            var command = new UpdateNewsCommand { Id = 1, Title = "Updated News" };

            // Asegúrate de que el mock de Send devuelva Unit.Value, ya que este es el tipo esperado
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateNewsCommand>(), default))
                         .ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Update(1, command);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task Delete_ReturnsNoContent_WhenNewsIsDeleted()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteNewsCommand>(), default))
                         .ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


    }
}
