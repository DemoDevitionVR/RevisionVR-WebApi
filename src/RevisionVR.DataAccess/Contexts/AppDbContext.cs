using RevisionVR.Domain.Entities.Devices;
using RevisionVR.Domain.Entities.Positions;
using Microsoft.EntityFrameworkCore;

namespace RevisionVR.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Device> Devices { get; set; }
    public DbSet<UserPosition> Positions { get; set; }
}