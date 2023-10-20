using Microsoft.EntityFrameworkCore;
using RevisionVR.DataAccess.Contexts;
using RevisionVR.WebApi.Configuration;
using RevisionVR.WebApi.Hubs;
using RevisionVR.WebApi.Middlewares;
using RevisionVR.WepApi.Extentions;
using RevisionVR.WepApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.ConfigureCourtsPolicy();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<UserPositionHub>("/NotificationHub");
app.MapHub<DevicePositionHub>("/DevicePositionHub");

app.Run();
