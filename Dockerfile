FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/MobileShopManagementSystem.Core/MobileShopManagementSystem.Core.csproj src/MobileShopManagementSystem.Core/
COPY src/MobileShopManagementSystem.Data/MobileShopManagementSystem.Data.csproj src/MobileShopManagementSystem.Data/
COPY src/MobileShopManagementSystem.Services/MobileShopManagementSystem.Services.csproj src/MobileShopManagementSystem.Services/
COPY src/MobileShopManagementSystem.Web/MobileShopManagementSystem.Web.csproj src/MobileShopManagementSystem.Web/
RUN dotnet restore "src/MobileShopManagementSystem.Web/MobileShopManagementSystem.Web.csproj"
COPY . .
RUN dotnet publish "src/MobileShopManagementSystem.Web/MobileShopManagementSystem.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MobileShopManagementSystem.Web.dll"]
