using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastucture.Persistence;

public class CarWorkshopDbContext : IdentityDbContext
{
    public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; } = default!;
    public DbSet<Domain.Entities.CarWorkshopService> Services { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Entities.CarWorkshop>(entity => { entity.OwnsOne(e => e.ContactDetails); });
        modelBuilder.Entity<Domain.Entities.CarWorkshop>().HasMany(c => c.Services)
            .WithOne(s => s.CarWorkshop).HasForeignKey(s => s.CarWorkshopId);
    }
}