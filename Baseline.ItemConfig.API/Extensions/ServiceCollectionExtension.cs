using Baseline.Common.Extensions;
using Baseline.Common.Uow.Abstractions;
using Baseline.ItemConfig.Application;
using Baseline.ItemConfig.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Baseline.ItemConfig.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<ItemConfigDbContext>(options =>
            {
                var cs = "Data Source=localhost,1433;Initial Catalog=ItemConfigDb;User ID=sa;Password=YourStrong!Pass123;Encrypt=True;TrustServerCertificate=True"; // builder.Configuration.GetConnectionString("ItemConfigDb");
                options.UseSqlServer(cs);
            });

            services.AddScoped<IBaseDbContext, ItemConfigDbContext>();
            services.RegisterUowRepository();    
            services.AddScoped<MasterHuntTypeService>();
            services.AddScoped<HuntTypeLicenseYearService>();
            return services;
        }
    }
}
