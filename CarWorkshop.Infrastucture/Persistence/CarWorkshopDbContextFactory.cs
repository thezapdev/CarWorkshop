using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarWorkshop.Infrastucture.Persistence;

public class CarWorkshopDbContextFactory : IDesignTimeDbContextFactory<CarWorkshopDbContext>
{
    public CarWorkshopDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__CarWorkshop")
            ?? "Server=(localdb)\\MSSQLLocalDB;Database=CarWorkshopDb;Trusted_Connection=True;TrustServerCertificate=True;";

        var optionsBuilder = new DbContextOptionsBuilder<CarWorkshopDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new CarWorkshopDbContext(optionsBuilder.Options);
    }
}

