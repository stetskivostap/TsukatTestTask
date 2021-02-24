using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Constants;
using DataAccessLayer.Repository;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TsukatTestTask.Entities;

namespace BuisnessLogicLayer.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task AddUser(User user)
        {
            user.RoleId = new Guid(Constant.UserRoleId);
            _userRepository.Add(user);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = _userRepository.GetOne(e => e.Id == id);
            _userRepository.Remove(user);
            await _unitOfWork.SaveChanges();
        }

        public IEnumerable<User> GetAllUser() => _userRepository.GetAll();                

        public async Task UpdateUser(Guid id, User updatedUser)
        {
            var user = _userRepository.GetOne(e => e.Id == id);
            user.Name = updatedUser.Name;
            user.Age = updatedUser.Age;
            _userRepository.Update(user);
            await _unitOfWork.SaveChanges();
        }
    }
}
