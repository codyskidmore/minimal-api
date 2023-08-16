FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Minimal.Api/Minimal.Api.csproj", "Minimal.Api/"]
RUN dotnet restore "Minimal.Api/Minimal.Api.csproj"
COPY . .
WORKDIR "/src/Minimal.Api"
RUN dotnet build "Minimal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Minimal.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Minimal.Api.dll"]
