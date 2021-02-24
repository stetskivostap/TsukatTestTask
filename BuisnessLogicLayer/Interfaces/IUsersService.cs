using BuisnessLogicLayer.Models;
using DataAccessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TsukatTestTask.Entities;


namespace BuisnessLogicLayer.Interfaces
{
    public interface IUsersService
    {
        public IEnumerable<User> GetAllUser();
        public Task UpdateUser(Guid id, User updatedUser);
        public Task DeleteUser(Guid id);
        public Task AddUser(User user);
        LoginResponse SignIn(LoginModel login);
    }
}
