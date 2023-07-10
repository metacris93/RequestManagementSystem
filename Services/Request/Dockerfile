#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN dotnet dev-certs https
WORKDIR /src
COPY ["Services/Request/RequestService.csproj", "Services/Request/"]
RUN dotnet restore "Services/Request/RequestService.csproj"
COPY . .
WORKDIR "/src/Services/Request"
RUN dotnet build "RequestService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RequestService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RequestService.dll"]
