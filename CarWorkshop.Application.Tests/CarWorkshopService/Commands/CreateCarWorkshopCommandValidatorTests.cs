using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshopService.Commands;
using CarWorkshop.Application.Commands.CreateCarWorkshopCommand;
using FluentValidation.TestHelper;
using CreateCarWorkshopCommandValidator = CarWorkshop.Application.CarWorkshopService.Commands.CreateCarWorkshopCommandValidator;

namespace CarWorkshop.Application.Test.CarWorkshopService.Commands;

public class CreateCarWorkshopCommandValidatorTests
{
    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveValidationErrors()
    {
      // Arrange
      var validator = new CreateCarWorkshopCommandValidator();
      var command = new CreateCarWorkshopServiceCommand()
      {
          Cost = "100 PLN",
          Description = "Test description",
          CarWorkshopEncodedName = "test-workshop"
      };
      // Act
      var result = validator.TestValidate(command);
      // Assert
      result.ShouldNotHaveAnyValidationErrors();
    }
    [Fact]
    public void Validate_WithInvalidCommand_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var validator = new CreateCarWorkshopCommandValidator();
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "",
            Description = "",
            CarWorkshopEncodedName = null
        };
        // Act
        var result = validator.TestValidate(command);
        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Cost);
        result.ShouldHaveValidationErrorFor(c => c.Description);
        result.ShouldHaveValidationErrorFor(c => c.CarWorkshopEncodedName);
    }
}