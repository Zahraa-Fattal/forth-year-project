using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurProject.IRepo;
using OurProject.Repo;
using OurProject.Repo.Profiles;
using OurProject.Repo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject
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
            services.AddTransient<AccessoryIRepo, AccessoryRepo>();
            services.AddTransient<CityIRepo, CityRepo>();
            services.AddTransient<DateTypeIRepo, DateTypeRepo>();
            services.AddTransient<RoleIRepo, RoleRepo>();
            services.AddTransient<RoomIRepo, RoomRepo>();
            services.AddTransient<VacationDateIRepo, VacationDateRepo>();
            services.AddTransient<StoreDetailIRepo, StoreDetailRepo>();
            services.AddTransient<StudentAccessoriesIRepo, StudentAccessoriesRepo>();
            services.AddTransient<StudentDateIRepo, StudentDateRepo>();
            services.AddTransient<StudentIRepo, StudentRepo>();
            services.AddTransient<StudyBranchIRepo, StudyBranchRepo>();
            services.AddTransient<UnitIRepo, UnitRepo>();
            services.AddTransient<UnitRoomIRepo, UnitRoomRepo>();
            services.AddTransient<UnitStoreIRepo, UnitStoreRepo>();
            services.AddTransient<UserIRepo, UserRepo>();
            services.AddTransient<DataBase.MyDbContext>();


            services.AddControllersWithViews();


            services
         .AddAutoMapper(typeof(AccessoryProfile).Assembly)
         .AddAutoMapper(typeof(CityProfile).Assembly)
         .AddAutoMapper(typeof(DateTypeProfile).Assembly)
         .AddAutoMapper(typeof(RoleProfile).Assembly)
         .AddAutoMapper(typeof(RoomProfile).Assembly)
         .AddAutoMapper(typeof(StoreDetailProfile).Assembly)
         .AddAutoMapper(typeof(StudentAccessoriesProfile).Assembly)
         .AddAutoMapper(typeof(StudentDateProfile).Assembly)
         .AddAutoMapper(typeof(StudentProfile).Assembly)
         .AddAutoMapper(typeof(VacationDateProfile).Assembly)
         .AddAutoMapper(typeof(StudyBranchProfile).Assembly)
         .AddAutoMapper(typeof(UnitProfile).Assembly)
         .AddAutoMapper(typeof(UnitRoomProfile).Assembly)
         .AddAutoMapper(typeof(UnitStoreProfile).Assembly)
         .AddAutoMapper(typeof(UserProfile).Assembly);
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
