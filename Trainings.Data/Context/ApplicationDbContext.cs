using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trainings.Data.Models;

namespace Trainings.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Training>? Trainings { get; set; }
        public DbSet<Technology>? Technologies { get; set; }
        public DbSet<User>? ApplicationUsers { get; set; }
    }
}
