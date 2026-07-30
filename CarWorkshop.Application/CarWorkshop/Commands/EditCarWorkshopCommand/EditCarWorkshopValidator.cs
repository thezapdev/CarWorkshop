using CarWorkshop.Application.Commands.CreateCarWorkshopCommand;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshopCommand;

public class EditCarWorkshopValidator : AbstractValidator<EditCarWorkshopCommand>
{
    public EditCarWorkshopValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(2).WithMessage("Description must be at least 2 characters long");

        RuleFor(x => x.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);

    }
}