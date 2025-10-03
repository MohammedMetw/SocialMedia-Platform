using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DB context configuratuib
            builder.Services.AddDbContext<SocialMedia.Infrastructure.Persistence.SocialMediaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<SocialMedia.Domain.Entities.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SocialMedia.Infrastructure.Persistence.SocialMediaDbContext>();
           
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
