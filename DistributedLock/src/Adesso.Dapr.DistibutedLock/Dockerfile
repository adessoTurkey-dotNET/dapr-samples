FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Adesso.Dapr.DistibutedLock/Adesso.Dapr.DistibutedLock.csproj", "Adesso.Dapr.DistibutedLock/"]
RUN dotnet restore "Adesso.Dapr.DistibutedLock/Adesso.Dapr.DistibutedLock.csproj"
COPY . .
WORKDIR "/src/Adesso.Dapr.DistibutedLock"
RUN dotnet build "Adesso.Dapr.DistibutedLock.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adesso.Dapr.DistibutedLock.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adesso.Dapr.DistibutedLock.dll"]
