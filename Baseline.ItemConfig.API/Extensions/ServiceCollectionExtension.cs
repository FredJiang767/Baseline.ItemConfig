using Baseline.Common.Extensions;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application;
using Baseline.ItemConfig.Infrastructure;

namespace Baseline.ItemConfig.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseDbContext, ItemConfigDbContext>();
            services.RegisterUowRepository();    
            services.AddScoped<MasterHuntTypeService>();
            return services;
        }
    }
}
