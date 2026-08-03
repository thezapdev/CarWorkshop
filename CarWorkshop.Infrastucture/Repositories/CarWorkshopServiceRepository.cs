using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

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
        await _dbContext.Services.AddAsync(service);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName)
    {
        return await _dbContext.Services
            .Include(s => s.CarWorkshop)
            .Where(s => s.CarWorkshop.EncodedName == encodedName)
            .ToListAsync();
    }
}