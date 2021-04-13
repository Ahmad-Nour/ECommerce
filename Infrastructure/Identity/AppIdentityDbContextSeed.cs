using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ahmad Nour",
                    Email = "Ahmad@test.com",
                    UserName = "Ahmad",
                    Address = new Address
                    {
                        FirstName = "Ahmad Nour",
                        LastName = "Al-Sabaggh",
                        City = "Hamah",
                        Street = "10",
                        State = "SY",
                        ZipCode = "121"
                    }

                };
                await userManager.CreateAsync(user, "P@$$w0rd");
            }
        }
    }
}