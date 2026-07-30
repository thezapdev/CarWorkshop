using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.Behaviors;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshopCommand;
using CarWorkshop.Application.Commands.CreateCarWorkshopCommand;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateCarWorkshopCommand));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(typeof(CarWorkshopMappingProfile));
        services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<EditCarWorkshopValidator>();
        services.AddFluentValidationClientsideAdapters();
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped(provider => new MapperConfiguration(cfg =>
        {
            var scope = provider.CreateScope();
            var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
            cfg.AddProfile(new CarWorkshopMappingProfile(userContext));
        }).CreateMapper());
    }
} 