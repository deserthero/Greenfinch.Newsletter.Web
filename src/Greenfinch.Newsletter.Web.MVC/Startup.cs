using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Greenfinch.Newsletter.Web.Infrastructure.EF.DAL;
using AutoMapper;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices;
using Greenfinch.Newsletter.Web.Core.Services.Services;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories;
using Greenfinch.Newsletter.Web.Infrastructure.EF.Repositories;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Greenfinch.Newsletter.Web.Common.Interfaces;
using Greenfinch.Newsletter.Web.Common;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures;
using Greenfinch.Newsletter.Web.Infrastructure.FakeEmailService;

namespace Greenfinch.Newsletter.Web.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
             {


             }).AddEntityFrameworkStores<ApplicationDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Auth/Login";
                options.SlidingExpiration = true;
            });


            // Custom Services Injection
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISubscriptionRepository, SubscriptionSqlRepository>();
            services.AddScoped<INewsletterSubscriptionService, NewsletterSubscriptionService>();

            var emailService = Configuration.GetSection("ApplicationSettings")["EmailService"];

            // Here i want only to show that the injection of a concrete implementation can be changed easily based on configuration
            if (string.IsNullOrEmpty(emailService))
                services.AddScoped<IEmailService, FakeEmailService>();
            else
                services.AddScoped<IEmailService, AnotherFakeEmailService>();




            services.AddSingleton<IAppConfigManager, AppConfigManager>();



            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              .AddDataAnnotationsLocalization(options =>
              {

              });




            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAppConfigManager appConfigManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            // Seed a sample User and role
            IdentityDataInitializer.SeedData(userManager, roleManager, appConfigManager);


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            // Localization: Here we are building a list of supported cultures which will be used in
            //               the RequestLocalizationOptions in the app.UseRequestLocalization call below.
            var supportedCultures = new[]
              {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-MX"),
                    new CultureInfo("fr-FR"),
              };

            // Localization: Here we are configuring the RequstLocalization including setting the supported cultures from above
            //               in the RequestLocalizationOptions. We are also setting the default request culture to be used
            //               for current culture. These options will be used wherever we request localized strings.
            //               For more information see https://docs.asp.net/en/latest/fundamentals/localization.html
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),

                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,

                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });


        }
    }
}
