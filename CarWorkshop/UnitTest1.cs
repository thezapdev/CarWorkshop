
namespace CarWorkshop;

public class UnitTest1
{
    [Fact]
    public void EncodeNameTest_ShouldSetEncodedName()
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
}