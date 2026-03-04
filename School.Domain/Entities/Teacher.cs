using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Subject { get; private set; }
        public Guid SchoolId { get; private set; }
        public School School { get; private set; }

        private Teacher() { }

        public Teacher(string fullName, string subject, Guid schoolId)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Subject = subject;
            SchoolId = schoolId;
        }

        public void Update(string fullName, string subject)
        {
            FullName = fullName;
            Subject = subject;
        }
    }
}
