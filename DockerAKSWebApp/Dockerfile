# -------------------------------------------------------
# BASE RUNTIME IMAGE (ASP.NET Core 8) - AMD64
# -------------------------------------------------------
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# -------------------------------------------------------
# BUILD IMAGE (SDK 8) - AMD64
# -------------------------------------------------------
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["DockerAKSWebApp.csproj", "./"]
RUN dotnet restore "DockerAKSWebApp.csproj"

# Copy entire project and publish
COPY . .
RUN dotnet publish "DockerAKSWebApp.csproj" -c Release -o /app/publish

# -------------------------------------------------------
# FINAL IMAGE
# -------------------------------------------------------
FROM base AS final
WORKDIR /app

# Copy published output into final image
COPY --from=build /app/publish .

# Start the application
ENTRYPOINT ["dotnet", "DockerAKSWebApp.dll"]
