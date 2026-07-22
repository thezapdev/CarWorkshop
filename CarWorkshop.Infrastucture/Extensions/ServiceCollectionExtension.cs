using CarWorkshop.Infrastucture.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastucture.Extensions; 

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Persistence.CarWorkshopDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CarWorkshop")));
        
        services.AddScoped<CarWorkshopSeeder>();
    }
}