using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Entities;

namespace School.Domain.Entities
{
    
        public class User
        {
            public Guid Id { get; private set; }
            public string Username { get; private set; }
            public string PasswordHash { get; private set; }
            public Guid SchoolId { get; private set; }
            public School UserSchool { get; private set; }

            private User() { }

            public User(string username, string passwordHash, Guid schoolId)
            {
                Id = Guid.NewGuid();
                Username = username;
                PasswordHash = passwordHash;
                SchoolId = schoolId;
            }
        
    }
}
