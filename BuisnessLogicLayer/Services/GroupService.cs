using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Group> _groupRepository;
        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _groupRepository = _unitOfWork.GetRepository<Group>();
        }
        public async Task AddGroup(string name)
        {
            var Group = new Group() { Name = name };
            _groupRepository.Add(Group);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteGroup(Guid id)
        {
            var Group = _groupRepository.GetOne(e => e.Id == id);
            _groupRepository.Remove(Group);
            await _unitOfWork.SaveChanges();
        }

        public IEnumerable<Group> GetAllGroups() => _groupRepository.GetAll();

        public async Task UpdateGroup(Guid id, Group updatedGroup)
        {
            var Group = _groupRepository.GetOne(e => e.Id == id);
            Group.Name = updatedGroup.Name;
            _groupRepository.Update(Group);
            await _unitOfWork.SaveChanges();
        }
    }
}
