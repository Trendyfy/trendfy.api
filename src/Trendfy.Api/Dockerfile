#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENV PORT=8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Trendfy.Api/Web.Api.csproj", "src/Trendfy.Api/"]
COPY ["src/Domain/Auth/Auth.csproj", "src/Domain/Auth/"]
COPY ["src/Domain/MusicAssistentAI/MusicAssistentAI.csproj", "src/Domain/MusicAssistentAI/"]
COPY ["src/Infrastructure/Infrastructure/Infrastructure.csproj", "src/Infrastructure/Infrastructure/"]
RUN dotnet restore "./src/Trendfy.Api/Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Trendfy.Api"
RUN dotnet build "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY src/Api/Certs/private_key.pem /app/Certs/private_key.pem
COPY src/Api/Certs/public_key.pem /app/Certs/public_key.pem


ENTRYPOINT ["dotnet", "Web.Api.dll"]