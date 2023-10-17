﻿using RevisionVR.WepApi.Models;
using RevisionVR.Service.Excaptions;

namespace RevisionVR.WebApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    public readonly RequestDelegate request;
    public readonly ILogger<ExceptionHandlerMiddleware> logger;
    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.request = request;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.request(context);
        }
        catch (DemoException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            });
        }

        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            this.logger.LogError(ex.ToString());
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            });
        }
    }
}