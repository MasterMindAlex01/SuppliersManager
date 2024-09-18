using Moq;
using SuppliersManager.Application.Features.Suppliers.Commands;
using SuppliersManager.Application.Features.Users.Commands;
using SuppliersManager.Application.Interfaces.Services;
using SuppliersManager.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersManager.Tests.Users.Commands
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly DeleteUserCommandHandler _handler;

        public DeleteUserCommandHandlerTests()
        {
            // Simular el repositorio de proveedores
            _userServiceMock = new Mock<IUserService>();

            // Crear una instancia del manejador con la dependencia simulada
            _handler = new DeleteUserCommandHandler(_userServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Should_DeleteUserAndReturnResult()
        {
            // Arrange
            string id = Guid.NewGuid().ToString();
            var command = new DeleteUserCommand(id);
            var resultExpected = await Result.SuccessAsync();

            // Configurar el mock del servicio para que devuelva un ID esperado
            _userServiceMock
                .Setup(service => service.DeleteAsync(It.IsAny<string>()))
                .ReturnsAsync(resultExpected);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userServiceMock.Verify(repo => repo.DeleteAsync(It.IsAny<string>()), Times.Once);
            Assert.Equal(resultExpected, result);
        }
    }
}
