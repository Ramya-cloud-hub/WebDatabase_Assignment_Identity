using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using WebAppAssignmentDATABASE_5.Models.Service;
using WebAppAssignmentDATABASE_5.Models.Repo;
using WebAppAssignmentDATABASE_5.Repo;
using WebAppAssignmentDATABASE_5.Data;

namespace WebAppAssignmentDATABASE_5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryRepo, DatabaseCountryRepo>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityRepo, DatabaseCityRepo>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILanguageRepo, DatabaseLanguageRepo>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<PeopleContext>(options =>
            {
                options.UseSqlServer(
Configuration.GetConnectionString("PeopleDB")).EnableSensitiveDataLogging();

            });

            services.Configure<IdentityOptions>(options =>
            {

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;


                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddControllersWithViews(op => op.Filters.Add(new AuthorizeFilter()));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllPolicy",
                                    builder =>
                                    {
                                        builder.AllowAnyOrigin()
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod();
                                    });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
           )
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
