using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IGroupService
    {
        public IEnumerable<Group> GetAllGroups();
        public Task UpdateGroup(Guid id, Group updatedGroup);
        public Task DeleteGroup(Guid id);
        public Task AddGroup(string name);
    }
}
