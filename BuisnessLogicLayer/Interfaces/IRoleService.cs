using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TsukatTestTask.Entities;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IRoleService
    {
        public IEnumerable<Role> GetAllRoles();
        public Task UpdateRole(Guid id, Role updatedRole);
        public Task DeleteRole(Guid id);
        public Task AddRole(string name);
    }
}
