using CarWorkshop.Application.Commands.CreateCarWorkshopCommand;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop;

public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
{
    public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.").MinimumLength(2)
            .WithMessage("Name should have atleast 2 characters.")
            .MaximumLength(20).WithMessage("Name should not exceed 20 characters.")
            .CustomAsync(async (name, context, cancellationToken) =>
            {
                var existingCarworkshop = await repository.GetByName(name);
                if (existingCarworkshop != null)
                {
                    context.AddFailure($"{name} A car workshop with the same name already exists.");
                }
            });

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(2).WithMessage("Description must be at least 2 characters long");

        RuleFor(x => x.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}