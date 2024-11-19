using asp_services.Controllers;
using lib_applications.Implementations;
using lib_applications.Interfaces;
using lib_repositories;
using lib_repositories.Implementations;
using lib_repositories.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicies
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Connection, Connection>();
            // Repositorios
            services.AddScoped<ISmokersRepository, SmokersRepository>();
            // Aplicaciones
            services.AddScoped<ISmokersApp, SmokersApp>();
            // Controladores
            //services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}