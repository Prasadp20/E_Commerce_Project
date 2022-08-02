using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Project
{
    public class Startup
    {
        public static string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        // below method is original 
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSession(options => {
        //        options.IdleTimeout = TimeSpan.FromSeconds(30);
        //        options.Cookie.IsEssential = true;
        //    });

        //    services.AddControllersWithViews();
        //}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ConnectionString = Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            ConnectionString = Configuration.GetValue<string>("ConnectionString:SqlConnection");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
