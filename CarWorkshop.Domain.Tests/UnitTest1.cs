
using FluentAssertions;

namespace CarWorkshop;

public class UnitTest1
{
    [Fact]
    public void  EncodeName_ShouldSetEncodedName()
    {
        // Arrange
        var carWorkshop = new Domain.Entities.CarWorkshop
        {
            Name = "My Car Workshop"
        };
        // Act
        carWorkshop.EncodeName();
        // Assert
        Assert.Equal("my-car-workshop", carWorkshop.EncodedName);
    }

    [Fact]
    public void EncodeName_ShouldThrowException_WhenNameIsNull()
    {
        // Arrange
        var carWorkshop = new Domain.Entities.CarWorkshop();
        
        // Act
       Action action = () => carWorkshop.EncodeName();
       // Assert
       action.Invoking(a =>a.Invoke()).Should().Throw<NullReferenceException>();
    }
}