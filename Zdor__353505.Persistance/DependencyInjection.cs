using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor__353505.Persistance.Data;
using Zdor__353505.Persistance.Repository;

namespace Zdor__353505.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork,EfUnitOfWork>();
            return services;
        }
        public static IServiceCollection AddPersistance(this IServiceCollection services,DbContextOptions options)
        {
            services.AddPersistance()
            .AddSingleton<AppDbContext>(
            new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }
}
