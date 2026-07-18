using AutoMapper;
using Baseline.Common.Extensions;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application;
using Baseline.ItemConfig.Application.MappingProfiles;
using Baseline.ItemConfig.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Baseline.ItemConfig.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<ItemConfigDbContext>(options =>
            {
                var cs = config.GetConnectionString("ItemConfigDb");
                options.UseSqlServer(cs);
            });

            services.AddAutoMapper(typeof(ItemConfigMappingProfile));

            services.AddScoped<IBaseDbContext, ItemConfigDbContext>();
            services.RegisterUowRepository();
            services.AddScoped<MasterHuntTypeService>();
            services.AddScoped<HuntTypeLicenseYearService>();
            services.AddScoped<OutletTypeService>();
            services.AddScoped<OutletService>();
            services.AddScoped<UiTabService>();
            services.AddScoped<UiSubTabService>();
            services.AddScoped<RootItemNumberService>();
            services.AddScoped<ItemService>();
            services.AddScoped<OutletTypeItemService>();
            return services;
        }
    }
}