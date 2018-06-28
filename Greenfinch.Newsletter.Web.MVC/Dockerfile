FROM microsoft/aspnetcore:2.1-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.1-nanoserver-1709 AS build
WORKDIR /src
COPY *.sln ./
COPY ../Greenfinch.Newsletter.Web.MVC/Greenfinch.Newsletter.Web.MVC.csproj ../Greenfinch.Newsletter.Web.MVC/
RUN dotnet restore
COPY . .
WORKDIR /src/../Greenfinch.Newsletter.Web.MVC
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Greenfinch.Newsletter.Web.MVC.dll"]
