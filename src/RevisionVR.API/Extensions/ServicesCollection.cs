using RevisionVR.DataAccess.IRepositories;
using RevisionVR.DataAccess.Repositories;
using RevisionVR.Service.Interfaces.Devices;
using RevisionVR.Service.Mappers;
using RevisionVR.Service.Services.Devices;

namespace RevisionVR.API.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IDeviceService, DeviceService>();
    }
}