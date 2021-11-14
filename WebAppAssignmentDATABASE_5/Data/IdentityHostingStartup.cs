using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppAssignmentDATABASE_5.Models.Repo;

[assembly: HostingStartup(typeof(WebAppAssignmentDATABASE_5.Data.IdentityHostingStartup))]
namespace WebAppAssignmentDATABASE_5.Data
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<UserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserDB")));

                services.AddIdentity<ApplicationUser, IdentityRole>(o =>
                {
                    o.SignIn.RequireConfirmedAccount = false;
                })
               .AddEntityFrameworkStores<UserContext>()
               .AddDefaultTokenProviders();

                
            });


        }
    }
}