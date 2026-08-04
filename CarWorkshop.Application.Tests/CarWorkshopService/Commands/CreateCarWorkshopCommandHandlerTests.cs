using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshopService.Commands;
using CarWorkshop.Domain.Interfaces;
using FluentAssertions;
using MediatR;
using Moq;

namespace CarWorkshop.Application.Test.CarWorkshopService.Commands;

public class CreateCarWorkshopCommandHandlerTests
{
    [Fact()]
    public async Task Handle_ShouldCreateCarWorkshopuService_WhenUserIsAuthorized()
    {
        // Arrange
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Test description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(x => x.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@test.com", new List<string> { "User" }));

        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);

        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object,
            carWorkshopServiceRepositoryMock.Object);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
    }
    
    [Fact()]
    public async Task Handle_ShouldCreateCarWorkshopuService_WhenUserIsModerator()
    {
        // Arrange
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Test description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(x => x.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@test.com", new List<string> { "Moderator" }));

        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);

        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object,
            carWorkshopServiceRepositoryMock.Object);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
    }
    
    [Fact()]
    public async Task Handle_ShouldCreateCarWorkshopuService_WhenUserIsNotAuthorized()
    {
        // Arrange
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Test description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(x => x.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@test.com", new List<string> { "User" }));

        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);

        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object,
            carWorkshopServiceRepositoryMock.Object);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
    }
    [Fact()]
    public async Task Handle_ShouldCreateCarWorkshopuService_WhenUserIsNotAuthenticated()
    {
        // Arrange
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Test description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(x => x.GetCurrentUser())
            .Returns((CurrentUser?)null);

        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);

        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object,
            carWorkshopServiceRepositoryMock.Object);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
    }
}