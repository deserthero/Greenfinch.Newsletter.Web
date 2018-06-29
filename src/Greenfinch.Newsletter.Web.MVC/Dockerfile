From microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /app
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "out/Greenfinch.Newsletter.Web.MVC.dll"]

