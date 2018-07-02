# Greenfinch.Newsletter.Web
Newsletter Application
# File System Hierarchy:
- src: This folder contains all projects and the solution
- tests: Contains unit test projects
- scripts: contains docker and any needed powershell, sh or bat files.
# Architecture Style
- Onion Architecture + Taking some benefits of DDD like using Specification pattern
- UI: MVC
- App Architecture: Domain Centeric (Onion) 
- Repository Pattern for data access
- Specification Pattern for filteration
# Technologies
- ASP.NET Core (Taking benfits of performance, EF Core Code First Localization, DI, OWIN Middlewares)
- Localdb as portable database solution (can be changed from connectionstring)
- XUNIT, MOQ, FluentAssertions for Unit Tests
- AutoMapper for Mapping ViewModels to Models and Vice Versa
- Docker
- Travis CI for continous Integration
# How to setup
- App should run without any issue on IIS or IIS Express
- Make sure to run with VisualStudio 2017 or from command line (.NET Core Runtime should be installed)
- Once the app run, it seed admin user and role to use it as admin (Can be changed from configurations)
# Setup with VisualStudio:
- Make sure to have version supports .Net Core and the .Net Core 2 runtime installed and open solution from src folder.
- Make sure to mark Presentation > Greenfinch.Newsletter.Web.MVC as Startup project
- Restore Nuget Packages
- Select the EntityFramework project from Nuget Package Manager then Update-Database to update the database from code and seed needed data (You may need to change connectionstring from appsettings and appsettings.development based on your prefrances)
- Run with IISExpress or IIS
- Note: If you wish you can use dotnet core command line commands to run the project.
# CI/CI and Dockrization
- I Used Travis CI for CI
- Also project prepared to be deployed correctly on Docker (Only there are a missing orchstration step in scripts/docker-compose.yml which need to add a docker image for nanoserver or sqlserver and adjust the network configuration between the dotnet core app docker and the sql docker)
