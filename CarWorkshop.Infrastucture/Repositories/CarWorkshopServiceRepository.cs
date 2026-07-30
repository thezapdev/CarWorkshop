using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastucture.Persistence;

namespace CarWorkshop.Infrastucture.Repositories;

public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
{
    private readonly CarWorkshopDbContext _dbContext;
    public CarWorkshopServiceRepository(CarWorkshopDbContext context)
    {
        _dbContext = context;
    }
    public async Task Create(CarWorkshopService service)
    {
        _dbContext.Services.Add(service);
        await _dbContext.SaveChangesAsync();
    }
}