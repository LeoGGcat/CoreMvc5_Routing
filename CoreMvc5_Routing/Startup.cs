using CoreMvc5_Routing.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc5_Routing
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
            services.AddControllersWithViews();

            services.AddDbContext<CarContext>(opt => opt.UseSqlServer(Configuration["DBConnection:CarContext_localdb"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //1.Car
                endpoints.MapControllerRoute(
                    name: "Car",
                    pattern: "car",
                    defaults: new { Controller = "AutoMobile", action = "index" }
                    );

                //2.Car/Brand/{brand}
                endpoints.MapControllerRoute(
                    name: "findbrand",
                    pattern: "Car/Brand/{brand?}",
                    defaults: new { controller = "Automobile", action = "FindBrand" }
                    );

                //3.car/Category/{cat?}
                endpoints.MapControllerRoute(
                    name: "findcategory",
                    pattern: "Car/Category/{cat=├тио}",
                    defaults: new { controller = "Automobile", action = "FindCategory" }
                    );

                //4.Car/Id/{id?}
                endpoints.MapControllerRoute(
                    name: "findid",
                    pattern: "Car/Id/{id?}",
                    defaults: new { controller = "Automobile", action = "FindId" });

                //5.Car/Year/{year?}
                endpoints.MapControllerRoute(
                    name: "findyear",
                    pattern: "Car/Year/{year=2017}",
                    constraints: new { year = @"^\d{4}$" },
                    defaults: new { controller = "Automobile", action = "FindYear" });

                //6.Car/Brand-Year/{brand}-{year}
                endpoints.MapControllerRoute(
                    name: "findbrandyear",
                    pattern: "Car/Brand-Year/{brand}-{year}",
                    constraints: new { brand = @"^[A-Za-z]+$", year = @"^\d{4}$" },
                    defaults: new { controller = "Automobile", action = "FindBrandYear" });

                //7.Car/TopSales/{topnumber}
                endpoints.MapControllerRoute(
                    name: "topsales",
                    pattern: "Car/TopSales/{topnumber=5}",
                    constraints: new { topnumber = @"^[1-9]+[0-9]*$" },
                    defaults: new { controller = "Automobile", action = "topsales" });

                //8.Car/Price/{min}-{max}
                endpoints.MapControllerRoute(
                    name:"price",
                    pattern: "Car/Price/{min=10000}-{max=50000}",
                    constraints: new { min = @"^(0|[1-9][0-9]*)", max = @"^(0|[1-9][0-9]*)" },
                    defaults: new { controller = "Automobile", action = "price" });
                    



                //Default
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "/",
                //    defaults: new { Controller = "AutoMobile", action = "index" }
                //    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AutoMobile}/{action=Index}/");

            });
        }
    }
}
