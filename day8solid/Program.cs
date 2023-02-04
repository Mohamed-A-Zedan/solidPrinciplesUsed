
using day8solid.Models;
using day8solid.Reposiotries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Identity;

namespace day8solid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<firmDBcontext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=Firm;Integrated Security=True ;TrustServerCertificate=True");
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<firmDBcontext>();
            builder.Services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 8;
                x.Password.RequireDigit = false;
                x.User.RequireUniqueEmail = true;
            });

            var app = builder.Build();
            //builder.Services.AddSingleton<IemployeeReposiotry, EmployeeReposiotry>();
            //builder.Services.AddScoped<IemployeeReposiotry, EmployeeReposiotry>();
            //builder.Services.AddTransient<IemployeeReposiotry, EmployeeReposiotry>();
         
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

