using CarWorkshop.Application.CarWorkshopService;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries.GetCarWorkshopServices;

public class GetCarWorkshopServicesQuery : IRequest<IEnumerable<CarWorkshopServiceDto>>
{
    public string EncodedName { get; set; } = default!;
}