FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HotelApp/HotelApp.csproj", "HotelApp/"]
RUN dotnet restore "HotelApp/HotelApp.csproj"
COPY . .
WORKDIR "/src/HotelApp"
RUN dotnet build "HotelApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelApp.dll"]
