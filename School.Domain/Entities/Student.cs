using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Guid SchoolId { get; private set; }
        public  School School { get; private set; }

        public ICollection<Grade> Grades { get; private set; } = new List<Grade>();

        private Student() { }

        public Student(string fullName, DateTime dateOfBirth, Guid schoolId)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            SchoolId = schoolId;
        }

        public void Update(string fullName, DateTime dateOfBirth)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
        }
    }
}
