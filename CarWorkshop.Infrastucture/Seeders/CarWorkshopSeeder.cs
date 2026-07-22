using CarWorkshop.Infrastucture.Persistence;

namespace CarWorkshop.Infrastucture.Seeders;

public class CarWorkshopSeeder
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (!_dbContext.CarWorkshops.Any())
            {
                var mazda = new Domain.Entities.CarWorkshop
                {
                    Name = "Mazda ASO",
                    Description = "Mazda car workshop",
                    About = "Mazda ASO is a professional car workshop specializing in Mazda vehicles. We provide high-quality maintenance and repair services to ensure your Mazda runs smoothly.",
                    ContactDetails = new Domain.Entities.CarWorkshopContactDetails
                    {
                        Email = "krakow232@gmail.com",
                        PhoneNumber = "+48123456789",
                        City = "Krakow",
                        PostalCode = "30-001",
                    }
                };
                mazda.EncodeName();
                _dbContext.CarWorkshops.Add(mazda);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}