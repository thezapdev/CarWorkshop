using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshopCommand;
using CarWorkshop.Application.CarWorkshopService;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings;

public class CarWorkshopMappingProfile : Profile
{
    public CarWorkshopMappingProfile(IUserContext userContext)
    {
        var user = userContext.GetCurrentUser();
        CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
            .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src =>
                new Domain.Entities.CarWorkshopContactDetails()
                {
                    City = src.City,
                    Street = src.Street,
                    Email = src.Email,
                    PostalCode = src.PostalCode,
                    PhoneNumber = src.PhoneNumber
                }));
        CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
            .ForMember(dest => dest.IsEditable,
                opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ContactDetails.City))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactDetails.Email))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

        CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
        CreateMap<CarWorkshopServiceDto, Domain.Entities.CarWorkshopService>().ReverseMap();
    }
}