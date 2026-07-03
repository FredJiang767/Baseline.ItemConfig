using Baseline.ItemConfig.API.Extensions;
using Baseline.ItemConfig.API.Fitlers;
using Microsoft.EntityFrameworkCore;
using Baseline.ItemConfig.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o => o.Filters.Add(new NotFoundResultFilterAttribute()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMasterHuntTypeServices();
builder.Services.AddDbContext<ItemConfigDbContext>(options =>
{
    var cs = "Data Source=localhost,1433;Initial Catalog=ItemConfigDb;User ID=sa;Password=YourStrong!Pass123;Encrypt=True;TrustServerCertificate=True"; // builder.Configuration.GetConnectionString("ItemConfigDb");
    options.UseSqlServer(cs);
});

var app = builder.Build();

var isContainer = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!isContainer)
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

// Ensure database is migrated and seeded on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ItemConfigDbContext>();
        context.Database.Migrate();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        throw;
    }
}

app.Run();
