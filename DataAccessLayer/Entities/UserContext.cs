using DataAccessLayer.Configuration;
using DataAccessLayer.Seed;
using Microsoft.EntityFrameworkCore;
using TsukatTestTask.Entities;

namespace DataAccessLayer.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new GroupConfiguration());
            builder.Seed();
        }
    }
}
