using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Workout1.Config;
using Workout1.Models;
using Workout1.Repositories;
using Workout1.Services;

namespace Workout1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            var config = new ServerConfig();
            Configuration.Bind(config);
            
            services.AddSingleton<IExerciseRepository, ExerciseRepository>();
            services.AddSingleton<IWorkoutServices, WorkoutServices.Services.WorkoutServices>();
            
            

            var mongoClient =
                new MongoClient(
                    config.MongoDB.ConnectionString);
            var db = mongoClient.GetDatabase("Workouts");
            services.AddSingleton(db);


            var options = new CreateIndexOptions() { Unique = true };
            IndexKeysDefinition<Exercise> keyField = "{ exerciseId: 1 }";
            await db.GetCollection<Exercise>("users").Indexes.CreateOneAsync(keyField, options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc();
            
            app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}