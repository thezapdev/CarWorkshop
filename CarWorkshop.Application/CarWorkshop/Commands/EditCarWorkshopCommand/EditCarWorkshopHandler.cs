using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshopCommand;

public class EditCarWorkshopHandler : IRequestHandler<EditCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IUserContext _userContext;

    public EditCarWorkshopHandler(ICarWorkshopRepository carWorkshopRepository, IUserContext userContext)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _userContext = userContext;
    }


    public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);
        var user = _userContext.GetCurrentUser();

        var isEdible = user != null && carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator");
       
        if (!isEdible )
        {
            return Unit.Value;
        }

        carWorkshop.ContactDetails ??= new Domain.Entities.CarWorkshopContactDetails();
        carWorkshop.Description = request.Description;
        carWorkshop.About = request.About;
        carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
        carWorkshop.ContactDetails.Email = request.Email;
        carWorkshop.ContactDetails.City = request.City;
        carWorkshop.ContactDetails.Street = request.Street;
        carWorkshop.ContactDetails.PostalCode = request.PostalCode;

        await _carWorkshopRepository.Commit();
        return Unit.Value;
    }
}