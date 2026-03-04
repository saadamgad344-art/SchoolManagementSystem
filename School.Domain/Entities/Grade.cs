using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Grade
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; private set; }
        public Student Student { get; private set; }
        public string Subject { get; private set; }
        public double Score { get; private set; }
        public Guid SchoolId { get; private set; }

        private Grade() { }

        public Grade(Guid studentId, string subject, double score, Guid schoolId)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            Subject = subject;
            Score = score;
            SchoolId = schoolId;
        }

        public void Update(string subject, double score)
        {
            Subject = subject;
            Score = score;
        }
    }
}
