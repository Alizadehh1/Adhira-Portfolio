using Adhira.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Adhira.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddDbContext<AdhiraDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {

                cfg.MapControllerRoute("default", pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
