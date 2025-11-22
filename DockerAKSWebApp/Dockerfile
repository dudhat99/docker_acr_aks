# ---------- RUNTIME (AMD64) ----------
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080   <-- REQUIRED

# ---------- BUILD (AMD64) ----------
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["DockerAKSWebApp.csproj", "./"]
RUN dotnet restore "DockerAKSWebApp.csproj"

COPY . .
RUN dotnet publish "DockerAKSWebApp.csproj" -c Release -o /app/publish

# ---------- FINAL IMAGE ----------
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DockerAKSWebApp.dll"]
