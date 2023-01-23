FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/EasyHiring.Api/EasyHiring.Api.csproj", "EasyHiring.Api/"]
RUN dotnet restore "src/EasyHiring.Api/EasyHiring.Api.csproj"
COPY . .
WORKDIR "/src/EasyHiring.Api"
RUN dotnet build "EasyHiring.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyHiring.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyHiring.Api.dll"]
