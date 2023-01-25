using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Bll.Mapping;
using TatterFitness.Bll.Services;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Dal.Persistence;

namespace TatterFitness.Videos
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
            services.AddAutoMapper(typeof(ModelMapping));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IExercisesService, ExercisesService>();
            services.AddScoped<IWorkoutsService, WorkoutsService>();
            services.AddScoped<IHistoriesService, HistoriesService>();
            services.AddScoped<IRoutinesService, RoutinesService>();
            services.AddScoped<IExerciseModifiersService, ExerciseModifiersService>();
            services.AddScoped<IRoutineExercisesService, RoutineExercisesService>();
            services.AddScoped<IWorkoutExerciseModifiersService, WorkoutExerciseModifiersService>();
            services.AddScoped<IWorkoutExercisesService, WorkoutExercisesService>();
            services.AddScoped<IWorkoutExerciseSetsService, WorkoutExerciseSetsService>();
            services.AddScoped<IVideoService, VideoService>();

            services.AddDbContext<TatterDb>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TatterDb")));
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
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
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
