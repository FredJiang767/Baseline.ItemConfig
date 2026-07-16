FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app

ENV ASPNETCORE_URLS=http://0.0.0.0:8080;https://0.0.0.0:8081
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["Baseline.ItemConfig.API/Baseline.ItemConfig.API.csproj", "Baseline.ItemConfig.API/"]
COPY ["Baseline.ItemConfig.Application/Baseline.ItemConfig.Application.csproj", "Baseline.ItemConfig.Application/"]
COPY ["Baseline.ItemConfig.Domain/Baseline.ItemConfig.Domain.csproj", "Baseline.ItemConfig.Domain/"]
COPY ["Baseline.ItemConfig.Infrastructure/Baseline.ItemConfig.Infrastructure.csproj", "Baseline.ItemConfig.Infrastructure/"]
RUN dotnet restore "./Baseline.ItemConfig.API/Baseline.ItemConfig.API.csproj"
COPY . .
WORKDIR "/src/Baseline.ItemConfig.API"
RUN dotnet build "./Baseline.ItemConfig.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Baseline.ItemConfig.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Baseline.ItemConfig.API.dll"]