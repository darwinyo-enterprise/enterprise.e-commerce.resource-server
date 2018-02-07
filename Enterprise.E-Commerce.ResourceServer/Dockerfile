FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY *.sln ./
COPY E-Commerce/Enterprise.E-Commerce.ResourceServer/Enterprise.E-Commerce.ResourceServer.csproj E-Commerce/Enterprise.E-Commerce.ResourceServer/
RUN dotnet restore
COPY . .
WORKDIR /src/E-Commerce/Enterprise.E-Commerce.ResourceServer
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Enterprise.E-Commerce.ResourceServer.dll"]
