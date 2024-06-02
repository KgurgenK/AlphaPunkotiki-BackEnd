FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AlphaPunkotiki/AlphaPunkotiki.WebApi.csproj", "AlphaPunkotiki/"]
COPY ["AlphaPunkotiki.Infrastructure/AlphaPunkotiki.Infrastructure.csproj", "AlphaPunkotiki.Infrastructure/"]
COPY ["AlphaPunkotiki.Domain/AlphaPunkotiki.Domain.csproj", "AlphaPunkotiki.Domain/"]
RUN dotnet restore "AlphaPunkotiki/AlphaPunkotiki.WebApi.csproj"
COPY . .
WORKDIR "/src/AlphaPunkotiki"
RUN dotnet build "AlphaPunkotiki.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlphaPunkotiki.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlphaPunkotiki.WebApi.dll"]
