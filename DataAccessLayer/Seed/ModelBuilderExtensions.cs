using DataAccessLayer.Constants;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using TsukatTestTask.Entities;


namespace DataAccessLayer.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = new Guid(Constant.AdminRoleId),
                    Name = "Admin"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("a560c6f1-c54b-4a8b-a3e6-312215bce364"),
                    Name = "Ostap",
                    Age = 20,
                    RoleId = new Guid(Constant.AdminRoleId),
                    GroupId = new Guid(Constant.AdminRoleId)
                });
            modelBuilder.Entity<Group>().HasData(
               new Group
               {
                   Id = new Guid(Constant.AdminRoleId),
                   Name = "PMP-41"
               });
        }
    }
}
