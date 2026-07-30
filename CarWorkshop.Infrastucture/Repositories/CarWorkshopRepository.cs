using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastucture.Repositories;

public class CarWorkshopRepository : ICarWorkshopRepository
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopRepository(CarWorkshopDbContext context)
    {
        _dbContext = context;
    }

    public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
    {
        _dbContext.Add(carWorkshop);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Domain.Entities.CarWorkshop?> GetByName(string name) =>

        _dbContext.CarWorkshops.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

    public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
    {
        return await _dbContext.CarWorkshops.ToListAsync();
    }

    public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
    {
        return await _dbContext.CarWorkshops.FirstAsync(x => x.EncodedName == encodedName);
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}