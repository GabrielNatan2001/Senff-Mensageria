FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Shared/SenffMensageria.Shared.csproj", "Shared/"]
COPY ["SenffMensageria.Application/SenffMensageria.Application.csproj", "SenffMensageria.Application/"]
COPY ["SenffMensageria.Domain/SenffMensageria.Domain.csproj", "SenffMensageria.Domain/"]
COPY ["SenffMensageria.Infrastructure/SenffMensageria.Infrastructure.csproj", "SenffMensageria.Infrastructure/"]
COPY ["SenffMensageria.API/SenffMensageria.API.csproj", "SenffMensageria.API/"]
RUN dotnet restore "SenffMensageria.API/SenffMensageria.API.csproj"
COPY ["Shared/", "Shared/"]
COPY ["SenffMensageria.Application/", "SenffMensageria.Application/"]
COPY ["SenffMensageria.Domain/", "SenffMensageria.Domain/"]
COPY ["SenffMensageria.Infrastructure/", "SenffMensageria.Infrastructure/"]
COPY ["SenffMensageria.API/", "SenffMensageria.API/"]
WORKDIR "/src/SenffMensageria.API"
RUN dotnet build "SenffMensageria.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SenffMensageria.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Nova etapa para instalar dotnet-ef e executar as migrations
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS migrations
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "SenffMensageria.API.dll"]