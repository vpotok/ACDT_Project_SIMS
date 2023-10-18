FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Project_SIMS/Project_SIMS.csproj", "Project_SIMS/"]
RUN dotnet restore "Project_SIMS/Project_SIMS.csproj"
COPY . .
WORKDIR "/src/Project_SIMS"
RUN dotnet build "Project_SIMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project_SIMS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project_SIMS.dll"]
