using Baseline.ItemConfig.API.Extensions;
using Baseline.ItemConfig.API.Fitlers;
using Baseline.ItemConfig.API.Infrastructure;
using Baseline.ItemConfig.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o => o.Filters.Add(new NotFoundResultFilterAttribute()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();
app.UseCors();

var isContainer = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
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

DbStartupHelper.MigrateAndSeedDb<ItemConfigDbContext>(app.Services, DbInitializer.Initialize);

app.Run();
