using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity.UI.Services; 
using SocialMedia.Infrastructure.Services;
using SocialMedia.Application.Common.Settings;
using SocialMedia.Application.Interface;
using SocialMedia.Infrastructure.Repository;
using SocialMedia.Application.Features.Post.Query;

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
           .AddEntityFrameworkStores<SocialMedia.Infrastructure.Persistence.SocialMediaDbContext>()
           .AddDefaultTokenProviders();


            
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFileStorageService, FileStorageService>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllPostsQuery).Assembly));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
