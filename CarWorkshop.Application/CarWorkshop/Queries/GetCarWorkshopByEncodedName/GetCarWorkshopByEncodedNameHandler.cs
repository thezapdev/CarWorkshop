using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries;

public class GetCarWorkshopByEncodedNameHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery,CarWorkshopDto>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;
    public GetCarWorkshopByEncodedNameHandler(ICarWorkshopRepository carWorkshopRepository,IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }
    public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var carworkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);
        var dto = _mapper.Map<CarWorkshopDto>(carworkshop);
        return dto;
    }
}