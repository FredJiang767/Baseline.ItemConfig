using Baseline.Common.Uow.Abstractions;
using Baseline.Common.Uow.Implement;
using Baseline.ItemConfig.Application;
using Baseline.ItemConfig.Domain.Abstractions;
using Baseline.ItemConfig.Infrastructure;
using Baseline.ItemConfig.Infrastructure.Repositories;

namespace Baseline.ItemConfig.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMasterHuntTypeServices(this IServiceCollection services)
        {
            services.AddScoped<MasterHuntTypeService>();
            services.AddScoped<IMasterHuntTypeRepository, MasterHuntTypeRepository>();
            services.AddScoped<IUnitOfWork<ItemConfigDbContext>, UnitOfWork<ItemConfigDbContext>>();
            return services;
        }
    }
}
