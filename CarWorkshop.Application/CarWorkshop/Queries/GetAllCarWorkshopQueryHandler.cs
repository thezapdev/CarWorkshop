using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries;

public class GetAllCarWorkshopQueryHandler : IRequestHandler<GetAllCarWorkshopQuery, IEnumerable<CarWorkshopDto>>
{
    
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;
    public GetAllCarWorkshopQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopQuery request, CancellationToken cancellationToken)
    {
        var carworkshops = await _carWorkshopRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carworkshops);
        return dtos;
    }
}