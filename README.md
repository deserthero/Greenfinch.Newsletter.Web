# Greenfinch.Newsletter.Web
Newsletter Application
# Architecture Style
- Onion Architecture + Taking some benefits of DDD like Specification pattern
- UI: MVC
- App Architecture: Domain Centeric (Onion) 
- Repository Pattern for data access
- Specification Pattern for filteration
# Technologies
- ASP.NET Core (Taking benfits of performance, EF Core Code First Localization, DI, OWIN Middlewares)
- XUNIT, MOQ, FluentAssertions for Unit Tests
- AutoMapper for Mapping ViewModels to Models and Vice Versa
- Docker
- Travis CI for continous Integration
# How to setup
- App should run without any issue on IIS or IIS Express
- Make sure to run with VisualStudio 2017 or from comand line (.NET Core Runtime should be installed)
- Once the app run, it seed admin user and role to use it as admin (Can be changed from configurations)