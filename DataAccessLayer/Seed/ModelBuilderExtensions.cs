using DataAccessLayer.Constants;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
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
                },            
                new Role
                {
                    Id = new Guid(Constant.UserRoleId),
                    Name = "User"
                }
            );
            modelBuilder.Entity<Group>().HasData(
               new Group
               {
                   Id = new Guid(Constant.AdminRoleId),
                   Name = "PMP-41"
               });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("a560c6f1-c54b-4a8b-a3e6-312215bce364"),
                    Name = "Ostap",
                    Age = 20,
                    Email = "stetskivostap@gmail.com",
                    Password = Hash.HashText("password", "salt"),
                    RoleId = new Guid(Constant.AdminRoleId),
                    GroupId = new Guid(Constant.AdminRoleId)
                },
                new User
                {
                    Id = new Guid(Constant.AdminRoleId),
                    Name = "Ostap",
                    Age = 20,
                    Email = "stetskiv@gmail.com",
                    Password = Hash.HashText("password", "salt"),
                    RoleId = new Guid(Constant.UserRoleId),
                    GroupId = new Guid(Constant.AdminRoleId)
                });
        }
    }
}
