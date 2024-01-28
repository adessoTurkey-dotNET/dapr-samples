# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Adesso.Dapr.PubSub.csproj", "./"]
RUN dotnet restore "Adesso.Dapr.PubSub.csproj"
COPY . .
RUN dotnet build "Adesso.Dapr.PubSub.csproj" -c Release -o /app/build
 
# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "Adesso.Dapr.PubSub.csproj" -c Release -o /app/publish
 
# Stage 3: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adesso.Dapr.PubSub.dll"]