using Microsoft.Net.Http.Headers;

namespace RevisionVR.WebApi.Configuration;

public static class CursPolicyConfiguration
{
    public static void ConfigureCourtsPolicy(this WebApplicationBuilder builder)
    {
        var allowOrigins = "AllowOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            options.AddPolicy("AllowHeaders", builder =>
            {
                builder.WithOrigins(allowOrigins)
                        .WithHeaders(HeaderNames.ContentType, HeaderNames.Server, HeaderNames.AccessControlAllowHeaders, HeaderNames.AccessControlExposeHeaders, "x-custom-header", "x-path", "x-record-in-use", HeaderNames.ContentDisposition);
            });
        });
    }
}
