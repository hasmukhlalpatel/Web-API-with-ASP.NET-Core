#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WebApi.Sample/WebApi.Sample.csproj", "src/WebApi.Sample/"]
RUN dotnet restore "src/WebApi.Sample/WebApi.Sample.csproj"
COPY . .
WORKDIR "/src/src/WebApi.Sample"
RUN dotnet build "WebApi.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Sample.dll"]