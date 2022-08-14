using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestionNAnswersForum.Data;

namespace QuestionNAnswersForum.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext _context = new ApplicationDbContext
                (serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            RoleManager<IdentityRole> _roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            UserManager<ApplicationUser> _userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            List<string> roles = new List<string>()
            {
                "Owner", "Administrator", "User"
            };



            foreach (string role in roles)
            {
                if (!_context.Roles.Any(r => r.Name == role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    await _context.SaveChangesAsync();
                }

            }


            if (!_context.Users.Any(u => u.Email == "zackm@gmail.com"))
            {
                ApplicationUser seededUser = new ApplicationUser
                {
                    Email = "zackm@gmail.com",
                    NormalizedEmail = "zackm@GMAIL.COM",
                    UserName = "zackm@gmail.com",
                    NormalizedUserName = "ZACKM@GMAIL.COM",
                    EmailConfirmed = true

                };


                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(seededUser, "Extraordinary");
                seededUser.PasswordHash = hashed;

                await _userManager.CreateAsync(seededUser);
                await _userManager.AddToRoleAsync(seededUser, "Owner");

                await _context.SaveChangesAsync();

            }

            if (!_context.Users.Any(u => u.Email == "victorolure@gmail.com"))
            {

                ApplicationUser secondSeededUser = new ApplicationUser
                {
                    Email = "victorolure@gmail.com",
                    NormalizedEmail = "VICTOROLURE@GMAIL.COM",
                    UserName = "victorolure@gmail.com",
                    NormalizedUserName = "VICTOROLURE@GMAIL.COM",
                    EmailConfirmed = true

                };


                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(secondSeededUser, "ManchesterUnited");
                secondSeededUser.PasswordHash = hashed;

                await _userManager.CreateAsync(secondSeededUser);
                await _userManager.AddToRoleAsync(secondSeededUser, "Administrator");

                await _context.SaveChangesAsync();

            }
            if (!_context.Users.Any(u => u.Email == "danedwarka@gmail.com"))
            {
                ApplicationUser thirdSeededUser = new ApplicationUser
                {
                    Email = "danedwarka@gmail.com",
                    NormalizedEmail = "DANEDWARKA@GMAIL.COM",
                    UserName = "danedwarka@gmail.com",
                    NormalizedUserName = "DANEDWARKA@GMAIL.COM",
                    EmailConfirmed = true

                };

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(thirdSeededUser, "programming");
                thirdSeededUser.PasswordHash = hashed;

                await _userManager.CreateAsync(thirdSeededUser);
                await _userManager.AddToRoleAsync(thirdSeededUser, "User");
                await _context.SaveChangesAsync();
            }

        }
    }
}
