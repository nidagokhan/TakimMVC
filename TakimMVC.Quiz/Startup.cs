using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TakimMVC.Quiz.Core.Contetxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakimMVC.Quiz.DAL.Concrete;
using TakimMVC.Quiz.DAL.Interface;

namespace TakimMVC.Quiz
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
            services.AddDbContext<MyContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("conn")));
            services.AddScoped<IKisiDAL, KisiDAL>();
            services.AddScoped<ITakimDAL, TakimDAL>();
            //services.AddScoped<IUnvanSayisiDAL, UnvanSayisiDAL>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

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
