using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Mappings;
using CarWorkshop.Domain.Entities;
using FluentAssertions;
using Moq;

namespace CarWorkshop.Application.Test.CarWorkshopService.Mappings;

public class CarWorkshopMappingProfileTests
{
    [Fact()]
    public void MappingProfile_ShouldMapCarWorkshopDtoToCarWorkshop()
    {
        // Arrange
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));
        var configuration =
            new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));
        var mapper = configuration.CreateMapper();
        // Act
        var dto = new CarWorkshopDto()
        {
            City = "Test City",
            PhoneNumber = "12331",
            PostalCode = "12345",
            Street = "Test Street"
        };
        var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);
        
        // Assert
        result.Should().NotBeNull();
        result.ContactDetails.Should().NotBeNull();
        result.ContactDetails.City.Should().Be(dto.City);
        result.ContactDetails.Street.Should().Be(dto.Street);
        result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
        result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);

    }
    
    public void MappingProfile_ShouldMapCarWorkshopToCarWorkshopDto()
    {
        // Arrange
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));
        var configuration =
            new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));
        var mapper = configuration.CreateMapper();
        // Act
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1",
            ContactDetails = new CarWorkshopContactDetails()
            {
                City = "City",
                Street = "Street",
                PostalCode = "12345",
                PhoneNumber = "123456789"
            }
        };
        var result = mapper.Map<CarWorkshopDto>(carWorkshop);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().Be(carWorkshop.ContactDetails.Street);
        result.Should().Be(carWorkshop.ContactDetails.City);
        result.Should().Be(carWorkshop.ContactDetails.PostalCode);
        result.Should().Be(carWorkshop.ContactDetails.PhoneNumber);

    }
}