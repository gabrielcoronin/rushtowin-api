#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RushToWin.API/RushToWin.API.csproj", "RushToWin.API/"]
RUN dotnet restore "RushToWin.API/RushToWin.API.csproj"
COPY . .
WORKDIR "/src/RushToWin.API"
RUN dotnet build "RushToWin.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RushToWin.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RushToWin.API.dll"]