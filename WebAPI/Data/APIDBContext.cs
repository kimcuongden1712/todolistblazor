using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class APIDBContext : IdentityDbContext<User, Role, Guid>
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
