using DataAccessLayer.Entities;
using System;

namespace TsukatTestTask.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public Guid RoleId { get; set; }

        public Guid GroupId { get; set; }

        public Role Role { get; set; }

        public Group Group { get; set; }
    }
}
