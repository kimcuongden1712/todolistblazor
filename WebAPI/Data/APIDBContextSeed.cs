using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class APIDBContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(APIDBContext context, ILogger<APIDBContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }

            if (!context.Todos.Any())
            {
                context.Todos.Add(new Todo()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
