using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastucture.Persistence;

public class CarWorkshopDbContext : DbContext
{
    public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.CarWorkshop>(entity => { entity.OwnsOne(e => e.ContactDetails); });
    }
}