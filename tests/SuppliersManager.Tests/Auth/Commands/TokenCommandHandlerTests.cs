using Moq;
using SuppliersManager.Application.Features.Auth.Commands;
using SuppliersManager.Application.Interfaces.Services;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Tests.Auth.Commands
{
    public class TokenCommandHandlerTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly TokenCommandHandler _handler;

        public TokenCommandHandlerTests()
        {
            // Simular el repositorio de proveedores
            _authServiceMock = new Mock<IAuthService>();

            // Crear una instancia del manejador con la dependencia simulada
            _handler = new TokenCommandHandler(_authServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Should_LoginAndResult()
        {
            // Arrange
            var command = new TokenCommand()
            {
                UserName = "Test",
                Password = "Test",
            };
            var expectedId = await Result<TokenCommandResponse>.SuccessAsync();

            // Configurar el mock del servicio para que devuelva un ID esperado
            _authServiceMock
                .Setup(service => service.LoginJWT(It.IsAny<TokenCommand>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _authServiceMock.Verify(repo => repo.LoginJWT(It.IsAny<TokenCommand>()), Times.Once);
            Assert.Equal(expectedId, result);
        }
    }
}
