using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using W2KMUXAPI.Extensions;
using W2KMUXAPI.Middlewares;
using W2KMUXBAL.Services;
using W2KMUXDAL.Data;

namespace W2KMUXAPI
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
            services.AddDbContext<W2KMUXContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ISuperstarBAL, SuperstarBAL>();
            services.AddTransient<IShowManagementBAL, ShowManagementBAL>();
            services.AddTransient<IPPVManagementBAL, PPVManagementBAL>();
            services.AddTransient<ITeamHistoryBAL, TeamHistoryBAL>();
            services.AddTransient<ITeamManagementBAL, TeamManagementBAL>();
            services.AddTransient<IChampionshipTypeManagementBAL, ChampionshipTypeManagementBAL>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
                //.AddJsonOptions(options =>
                //{
                //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                //});
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureExceptionHandler(env); // using customize middleware

            //app.ConfigureBuiltinExceptionHandler(env); // for built in exception handler

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); // Not best practice

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
