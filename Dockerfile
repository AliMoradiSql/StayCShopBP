FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/StayCShop.Web.Host/StayCShop.Web.Host.csproj", "src/StayCShop.Web.Host/"]
COPY ["src/StayCShop.Web.Core/StayCShop.Web.Core.csproj", "src/StayCShop.Web.Core/"]
COPY ["src/StayCShop.Application/StayCShop.Application.csproj", "src/StayCShop.Application/"]
COPY ["src/StayCShop.Core/StayCShop.Core.csproj", "src/StayCShop.Core/"]
COPY ["src/StayCShop.EntityFrameworkCore/StayCShop.EntityFrameworkCore.csproj", "src/StayCShop.EntityFrameworkCore/"]
WORKDIR "/src/src/StayCShop.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/StayCShop.Web.Host", "src/StayCShop.Web.Host"]
COPY ["src/StayCShop.Web.Core", "src/StayCShop.Web.Core"]
COPY ["src/StayCShop.Application", "src/StayCShop.Application"]
COPY ["src/StayCShop.Core", "src/StayCShop.Core"]
COPY ["src/StayCShop.EntityFrameworkCore", "src/StayCShop.EntityFrameworkCore"]
WORKDIR "/src/src/StayCShop.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "StayCShop.Web.Host.dll"]
