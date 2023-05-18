using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static SportsStore.Models.ApplicationDbContext;

namespace SportsStore.Models
{
	public class IdentitySeedData
	{
		private const string adminUser = "Admin";
		private const string adminPassword = "Secret123$";
		private const string Role = "ADMIN";

		public static async void EnsurePopulated(IApplicationBuilder app)
		{
			AppIdentityDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
				.GetRequiredService<AppIdentityDbContext>();
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}

			UserManager <IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();

			IdentityUser user = await userManager.FindByNameAsync(adminUser);
			if (user == null)
			{
				user = new IdentityUser("Admin");
				user.Email = "admin@example.com";
				user.PhoneNumber = "555-1234";
				await userManager.CreateAsync(user, adminPassword);
			}
		}
	}
}
