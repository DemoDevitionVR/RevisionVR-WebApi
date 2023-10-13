using RevisionVR.DataAccess.Contexts;
using RevisionVR.DataAccess.IRepositories;
using RevisionVR.DataAccess.Repositories;
using RevisionVR.Service.Interfaces.Devices;
using RevisionVR.Service.Interfaces.Positions;
using RevisionVR.Service.Mappers;
using RevisionVR.Service.Services.Devices;
using RevisionVR.Service.Services.Positions;

namespace RevisionVR.WepApi.Extentions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddDbContext<AppDbContext>();

        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IPositionService, PositionService>();
    }
}