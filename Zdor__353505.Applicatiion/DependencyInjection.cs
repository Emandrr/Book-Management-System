using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicatiion(this IServiceCollection services)
        {
            services.AddMediatR(conf =>

           conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}
