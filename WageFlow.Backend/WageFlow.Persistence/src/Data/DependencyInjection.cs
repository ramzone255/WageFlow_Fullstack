using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Persistence.src.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddDbContext<WageFlowDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDbString"),
            b => b.MigrationsAssembly(typeof(WageFlowDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<IWageFlowDbContext>(provider =>
            provider.GetService<WageFlowDbContext>());
            return services;
        }
    }
}
