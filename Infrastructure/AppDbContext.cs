using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s29792.Models;

namespace PJATK_APBD_Cw4_s29792.Infrastructure;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pc>().HasData([
            new Pc
            {
                Id = 1,
                Name = "Pc 1",
                Weight = new decimal(5.4),
                Warranty = 3,
                CreatedAt = new DateTime(2020, 10, 10, 10, 15, 0),
                Stock = 4
            }
        ]);

        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "HP",
                FullName = "Hewlett-Packard",
                Date = new DateOnly(1939, 07, 02)
            }
            ]);

        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType
            {
                Id = 1,
                Abbreviation = "RAM",
                Name = "Random Access Memory"
            }
        ]);

        modelBuilder.Entity<Component>().HasData([
            new Component
            {
                Code = "APX0423MNS",
                Name = "Super RAM",
                Description = "Fast and big",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            }
        ]);

        modelBuilder.Entity<PcComponent>().HasData([
            new PcComponent
            {
                PcId = 1,
                ComponentCode = "APX0423MNS",
                Amount = 15
            }
            ]);
    }
}