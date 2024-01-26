FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Secrets/Adesso.Dapr.SecretManagement/Adesso.Dapr.SecretManagement.csproj", "Secrets/Adesso.Dapr.SecretManagement/"]
RUN dotnet restore "Secrets/Adesso.Dapr.SecretManagement/Adesso.Dapr.SecretManagement.csproj"
COPY . .
WORKDIR "/src/Secrets/Adesso.Dapr.SecretManagement"
RUN dotnet build "Adesso.Dapr.SecretManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adesso.Dapr.SecretManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adesso.Dapr.SecretManagement.dll"]
