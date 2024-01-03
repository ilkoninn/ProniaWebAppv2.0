using Microsoft.EntityFrameworkCore;
using ProniaWebApp.Business.Services;
using ProniaWebApp.DAL.Context;
using ProniaWebApp.DAL.Repositories.Implementations;
using ProniaWebApp.DAL.Repositories.Interfaces;

namespace ProniaWebApp.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddServices();
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();

            app.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "Home",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}
