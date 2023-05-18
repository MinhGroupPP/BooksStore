using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static SportsStore.Models.ApplicationDbContext;

namespace SportsStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }); 

            builder.Services.AddDbContext<StoreDbContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
            });
            builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
            builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

            builder.Services.AddRazorPages();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer
                (builder.Configuration["ConnectionStrings:IdentityConnection"]));
            builder.Services.AddIdentity <IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRequestLocalization(opts =>
            {
                opts.AddSupportedCultures("en-US").AddSupportedUICultures("en-US").SetDefaultCulture("en-US");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("catpage", "{category}/Page{productPage:int}",
               new { Controller = "Home", action = "Index"});

            app.MapControllerRoute("page", "Page{productPage:int}",
                new {Controller = "Home", action= "Index", productPage = 1});

            app.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", productPage = 1 });

            app.MapControllerRoute("pagination", "Products/Page{productPage}",
                new { Controller = "Home", action = "Index", productPage = 1 });

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();

            app.MapRazorPages();

            app.MapBlazorHub();
            app.MapFallbackToPage("/admin/{*catchall}","/Admin/Index");

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
            app.Run();
        }
    }
}