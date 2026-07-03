# Use the official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["NuGet.Config", "."]
COPY ["Baseline.ItemConfig.API/Baseline.ItemConfig.API.csproj", "HBaseline.ItemConfig.API/"]
COPY ["Baseline.ItemConfig.Application/Baseline.ItemConfig.Application.csproj", "Baseline.ItemConfig.Application/"]
COPY ["Baseline.ItemConfig.Domain/Baseline.ItemConfig.Domain.csproj", "Baseline.ItemConfig.Domain/"]
COPY ["Baseline.ItemConfig.Infrastructure/Baseline.ItemConfig.Infrastructure.csproj", "Baseline.ItemConfig.Infrastructure/"]

RUN dotnet restore  --configfile NuGet.Config "HBaseline.ItemConfig.API/Baseline.ItemConfig.API.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
WORKDIR "/src/Baseline.ItemConfig.API"
RUN dotnet build "Baseline.ItemConfig.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Baseline.ItemConfig.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET 8 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Create a non-root user for security
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

COPY --from=publish /app/publish .

# Expose port 8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Baseline.ItemConfig.API.dll"]
