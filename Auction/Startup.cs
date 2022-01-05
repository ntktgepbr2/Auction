using Auction.Data.DatabaseContext;
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

namespace Auction
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
            services.AddDbContext<AuctionDbContext>(options =>
                options.EnableSensitiveDataLogging().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Singleton);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => //CookieAuthenticationOptions
        {
                        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });

            services.AddControllersWithViews(options => options.SuppressAsyncSuffixInActionNames = false);
            services.AddMvc();  
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Auction API", Version = "v1" });
            });

            //services.AddHealthChecks()
            //    .AddMongoDb(
            //        mongoDbSettings.ConnectionString,
            //        name: "mongodb",
            //        timeout: TimeSpan.FromSeconds(3),
            //        tags: new[] {"ready"});

            services.AddBusinessLayerDependencyInjections();
            services.AddDataLayerDependencyInjections();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => option.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(option => option.SwaggerEndpoint(swaggerOptions.UiEndPoint, swaggerOptions.Description));

            app.UseRouting();
            
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                
                //endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
                //{
                //    Predicate = (check) => check.Tags.Contains("ready")

                //});

                //endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
                //{
                //    Predicate = (_) => false
                //});
            });
        }
    }
}
