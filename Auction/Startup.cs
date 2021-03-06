using System;
using System.IO;
using Auction.Business.Services.Logging;
using Auction.Business.Services.Users;
using Auction.Data.DatabaseContext;
using Auction.Extensions;
using Auction.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Auction.Models;
using Microsoft.OpenApi.Models;
using Auction.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auction.Infrastructure.Hubs;
using NLog;

namespace Auction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "\\nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuctionDbContext>(options =>
                options.EnableSensitiveDataLogging().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
        {
                        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });
            services.AddAutoMapper(typeof(Startup));
            services.AddBusinessLayerDependencyInjections();
            services.AddDataLayerDependencyInjections();
            services.AddControllersWithViews(options => options.SuppressAsyncSuffixInActionNames = false);
            services.AddSignalR(options=>options.ClientTimeoutInterval = System.TimeSpan.FromMinutes(5));
            services.AddMvc();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerService logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureCustomExceptionMiddleware();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<BidHub>("/Bid/BidItemAsync");
            });
        }
    }
}
