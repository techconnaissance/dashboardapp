using System;
using Microsoft.Extensions.DependencyInjection;

namespace DashboardApi.Middleware
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(
              options => options.AddPolicy("AllowCors",
                  builder =>
                  {
                      builder
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      //  .AllowCredentials();
                  })
              );
        }
    }
}
