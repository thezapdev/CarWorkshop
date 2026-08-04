using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.Queries; // Sprawdź czy nazwa query na pewno jest poprawna
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace CarWorkshop.MVC.Tests;

public class CarWorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CarWorkshopControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Index_ReturnsViewWithExpectedData_ForExistingWorkshops()
    {
        // Arrange
        var carWorkshops = new List<CarWorkshopDto>()
        {
            new CarWorkshopDto()
            {
                Name = "Workshop 1"
            },
            new CarWorkshopDto()
            {
                Name = "Workshop 2"
            }
        };

        var mockMediator = new Mock<IMediator>();
        
        mockMediator
            .Setup(m => m.Send(It.IsAny<GetAllCarWorkshopQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(carWorkshops);

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped(_ => mockMediator.Object);
            });
        }).CreateClient();

        // Act
        var response = await client.GetAsync("/CarWorkshop/Index");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        
        content.Should().Contain("Workshop 1")
               .And.Contain("Workshop 2");
    }
}