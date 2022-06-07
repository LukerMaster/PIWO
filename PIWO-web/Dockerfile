#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PIWO-web/PIWO-web.csproj", "PIWO-web/"]
RUN dotnet restore "PIWO-web/PIWO-web.csproj"
COPY . .
WORKDIR "/src/PIWO-web"
RUN dotnet build "PIWO-web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PIWO-web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PIWO-web.dll"]