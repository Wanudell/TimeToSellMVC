using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeToSell.Services.Abstractions;
using TimeToSell.Services.Concretes;

namespace TimeToSell.Services.Extensions
{
    public static class ServiceExtensionCollections
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}