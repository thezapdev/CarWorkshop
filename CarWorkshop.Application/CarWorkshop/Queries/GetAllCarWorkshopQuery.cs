using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries;

public class GetAllCarWorkshopQuery : IRequest<IEnumerable<CarWorkshopDto>>
{
    
}