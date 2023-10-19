using Microsoft.EntityFrameworkCore;
using RevisionVR.Domain.Entities.Devices;

namespace RevisionVR.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Device> Devices { get; set; }
}