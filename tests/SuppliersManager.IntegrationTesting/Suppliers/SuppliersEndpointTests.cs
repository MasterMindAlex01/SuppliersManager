
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using SuppliersManager.Api;
using SuppliersManager.Api.Configurations;
using SuppliersManager.Application.Features.Suppliers.Commands;
using SuppliersManager.Application.Models.Responses.Suppliers;
using SuppliersManager.Shared.Wrapper;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SuppliersManager.IntegrationTesting.Suppliers
{
    public class SuppliersEndpointTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private const string urlController = "/v1/Suppliers";
        private readonly HttpClient _client;

        public SuppliersEndpointTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllSuppliers_ReturnsOkResponse()
        {
            // Arrange
            var response = await _client.GetAsync($"{urlController}/GetAll?pageNumber=1&pagesize=10");

            // Act
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadFromJsonAsync<PaginatedResult<SupplierResponse>>();
            Assert.NotEmpty(content!.Data);
        }

        [Fact]
        public async Task CreateSupplier_ReturnsCreatedResponse()
        {
            // Arrange
            var newSupplier = new CreateSupplierCommand()
            {
                Address = "cra 50 # 45- 50",
                City = "Medellin",
                Email = "alex@example.com",
                RegisteredName = "EmpresaTest",
                State = "Antioquia",
                TIN = "9825255245-45"
            };
            var content = new StringContent(JsonSerializer.Serialize(newSupplier), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"{urlController}/create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdId = JsonSerializer.Deserialize<Result<string>>(responseContent);
            var result = await Result<string>.SuccessAsync();

            Assert.NotEqual(result, createdId);
        }
    }
}
