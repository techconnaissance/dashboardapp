using System;
using Dashboard.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Dashboard.Model;
using Dashboard.Data;
using Business;

namespace DashboardApi.DI
{
    public static class IDashboardExtension
    {
        public static IServiceCollection RegisterApp(this IServiceCollection services)
        {
            #region ConnectionString
            services.AddDbContext<DashboardContext>(option =>
            {
                option.UseSqlServer(Config.ConnectionString);
            });
            #endregion

            #region "Factories DI"
            services.AddScoped<IDashboardFactory, DashboardFactory>();
            #endregion

            #region Business
            services.AddScoped<IDashboardService, DashboardService>();
            #endregion

            return services;
        }
    }
}
