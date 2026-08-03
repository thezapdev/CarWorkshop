using FluentValidation;

namespace CarWorkshop.Application.CarWorkshopService.Commands;

public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
{
    public CreateCarWorkshopCommandValidator()
    {
        RuleFor(x => x.CarWorkshopEncodedName)
            .NotEmpty().WithMessage("Car workshop encoded name is required.")
            .MaximumLength(100).WithMessage("Car workshop encoded name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Cost)
            .NotEmpty().WithMessage("Cost is required.")
            .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("Cost must be a valid decimal number with up to two decimal places.");
    }
}