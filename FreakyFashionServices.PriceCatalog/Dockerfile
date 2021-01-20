#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FreakyFashionServices.PriceCatalog/FreakyFashionServices.PriceCatalog.csproj", "FreakyFashionServices.PriceCatalog/"]
RUN dotnet restore "FreakyFashionServices.PriceCatalog/FreakyFashionServices.PriceCatalog.csproj"
COPY . .
WORKDIR "/src/FreakyFashionServices.PriceCatalog"
RUN dotnet build "FreakyFashionServices.PriceCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreakyFashionServices.PriceCatalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreakyFashionServices.PriceCatalog.dll"]
