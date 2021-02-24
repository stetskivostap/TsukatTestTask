using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Repository;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TsukatTestTask.Entities;

namespace BuisnessLogicLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.GetRepository<Role>();
        }
        public async Task AddRole(string name)
        {
            var role = new Role() { Name = name };
            _roleRepository.Add(role);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteRole(Guid id)
        {
            var role = _roleRepository.GetOne(e => e.Id == id);
            _roleRepository.Remove(role);
            await _unitOfWork.SaveChanges();
        }

        public IEnumerable<Role> GetAllRoles() => _roleRepository.GetAll();        

        public async Task UpdateRole(Guid id, Role updatedRole)
        {
            var role = _roleRepository.GetOne(e => e.Id == id);
            role.Name = updatedRole.Name;            
            _roleRepository.Update(role);
            await _unitOfWork.SaveChanges();
        }
    }
}
