using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastucture.Migrations;
using CarWorkshop.Infrastucture.Persistence;
using CarWorkshop.Infrastucture.Repositories;
using CarWorkshop.Infrastucture.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastucture.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CarWorkshopDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CarWorkshop.Domain.Tests")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CarWorkshopDbContext>();

        services.AddScoped<CarWorkshopSeeder>();
        services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
        services.AddScoped<ICarWorkshopServiceRepository, CarWorkshopServiceRepository>();
    }
}