FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
RUN apt-get update && apt-get -y install iputils-ping
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Demo.csproj", ""]
RUN dotnet restore "./Demo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.dll"]