using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Commands;

public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IUserContext _userContext;
    private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
    public CreateCarWorkshopCommandHandler(IUserContext userContext, ICarWorkshopRepository carWorkshopRepository,ICarWorkshopServiceRepository carWorkshopServiceRepository)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _userContext = userContext;
        _carWorkshopServiceRepository = carWorkshopServiceRepository;
    }
    public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName);
        var user = _userContext.GetCurrentUser();

        var isEdible = user != null && carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator");
       
        if (!isEdible )
        {
            return Unit.Value;
        }
        var carWorkshopService = new Domain.Entities.CarWorkshopService
        {
            Description = request.Description,
            Cost = request.Cost,
            CarWorkshopId = carWorkshop.Id
        };
        await _carWorkshopServiceRepository.Create(carWorkshopService);
        return Unit.Value;
    }
}