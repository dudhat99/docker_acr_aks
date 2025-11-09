
# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerAKSWebApp/DockerAKSWebApp.csproj", "DockerAKSWebApp/"]
RUN dotnet restore "./DockerAKSWebApp/DockerAKSWebApp.csproj"
COPY . .
WORKDIR "/src/DockerAKSWebApp"
RUN dotnet build "./DockerAKSWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerAKSWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerAKSWebApp.dll"]


## Base image for runtime
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 8080
#
## Build stage
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#COPY ["DockerAKSWebApp.csproj", "./"]
#RUN dotnet restore "./DockerAKSWebApp.csproj"
#COPY . .
#RUN dotnet publish "DockerAKSWebApp.csproj" -c Release -o /app/publish
#
## Final stage
#FROM base AS final
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "DockerAKSWebApp.dll"]