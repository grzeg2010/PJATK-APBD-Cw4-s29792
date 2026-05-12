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
    }
}