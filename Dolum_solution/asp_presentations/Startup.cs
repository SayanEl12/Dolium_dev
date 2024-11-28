using lib_comunications.Implementations;
using lib_comunications.Interfaces;
using lib_presentations.Implementations;
using lib_presentations.Interfaces;
namespace asp_presentations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Comunicaciones
            services.AddScoped<IUsersComunication, UsersComunication>();
            services.AddScoped<ISmokersComunication, SmokersComunication>();
            services.AddScoped<ISalesComunication, SalesComunication>();
            services.AddScoped<IImagesComunication, ImagesComunication>();
            services.AddScoped<IAuthenticateComunication, AuthenticateComunication>();
            // Presentaciones
            services.AddScoped<IUsersPresentation, UsersPresentation>();
            services.AddScoped<ISmokersPresentation, SmokersPresentation>();
            services.AddScoped<ISalesPresentation, SalesPresentation>();
            services.AddScoped<IImagesPresentation, ImagesPresentation>();
            services.AddScoped<IAuthenticatePresentation, AuthenticatePresentation>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}
