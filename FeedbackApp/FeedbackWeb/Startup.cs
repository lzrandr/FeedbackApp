using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Feedback.Data;
using Feedback.Domain;
using FeedbackWeb.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Feedback.Data.CourseRepository;

namespace FeedbackWeb
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
          
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<FeedbackContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("FeedbackWeb"));
            });

            

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IFeedBackRepository, FeedbackRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(CourseProfile));
            services.AddAutoMapper(typeof(FeedbackProfile));
            services.AddAutoMapper(typeof(TeacherProfile));
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
                name: "Student",
                pattern: "{area=Student}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                //name: "Admin",
                //pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
               name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });





        }
    }
}
