using Moq;
using SuppliersManager.Application.Features.Suppliers.Commands;
using SuppliersManager.Application.Interfaces.Services;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Tests.Suppliers.Commands
{
    public class DeleteSupplierCommandHandlerTests
    {
        private readonly Mock<ISupplierService> _supplierServiceMock;
        private readonly DeleteSupplierCommandHandler _handler;

        public DeleteSupplierCommandHandlerTests()
        {
            // Simular el repositorio de proveedores
            _supplierServiceMock = new Mock<ISupplierService>();

            // Crear una instancia del manejador con la dependencia simulada
            _handler = new DeleteSupplierCommandHandler(_supplierServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Should_DeleteSupplierAndReturnResult()
        {
            // Arrange
            string id = Guid.NewGuid().ToString();
            var command = new DeleteSupplierCommand(id);
            var resultExpected = await Result.SuccessAsync();

            // Configurar el mock del servicio para que devuelva un ID esperado
            _supplierServiceMock
                .Setup(service => service.DeleteAsync(It.IsAny<string>()))
                .ReturnsAsync(resultExpected);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _supplierServiceMock.Verify(repo => repo.DeleteAsync(It.IsAny<string>()), Times.Once);
            Assert.Equal(resultExpected, result);
        }
    }
}
