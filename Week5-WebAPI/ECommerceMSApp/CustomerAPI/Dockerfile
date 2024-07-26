FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV CustomerDB="Server=192.168.4.24,1433; Database=CustomerDb; User=sa; Password=H4ck5H4ck5; TrustServerCertificate=true"
#Server=host.docker.internal,1433
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerAPI/CustomerAPI.csproj", "CustomerAPI/"]
COPY ["CustomerAPI.ApplicationCore/CustomerAPI.ApplicationCore.csproj", "CustomerAPI.ApplicationCore/"]
COPY ["CustomerAPI.Infrastructure/CustomerAPI.Infrastructure.csproj", "CustomerAPI.Infrastructure/"]
RUN dotnet restore "CustomerAPI/CustomerAPI.csproj"
COPY . .
WORKDIR "/src/CustomerAPI"
RUN dotnet build "CustomerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CustomerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerAPI.dll"]
