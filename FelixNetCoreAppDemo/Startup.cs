using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FelixNetCoreAppDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FelixNetCoreAppDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add support for controllers.
            services.AddControllersWithViews();

            // add  Interface service
            services.AddSingleton<IClock,ChinaClock>();    //once other type request IClock interface and accomplish, return instance of ChinaClock class

            // register Departmentservice and EmployeeService
            services.AddSingleton<IDepartmentService, DepartmentService>();

            services.AddSingleton<IEmployeeService, EmployeeService>();



            // Add support for Razor pages
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // Add support of using html,css,js and other static files
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Map controller route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"  //default no input name of controller, it is Home
                );
            });
        }
    }
}
