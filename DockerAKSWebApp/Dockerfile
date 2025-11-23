# ---------- RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["DockerAKSWebApp.csproj", "./"]
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /publish

# ---------- FINAL IMAGE ----------
FROM base AS final
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "DockerAKSWebApp.dll"]
