using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class School
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LogoUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Navigation
        public ICollection<Student> Students { get; private set; } = new List<Student>();
        public ICollection<Teacher> Teachers { get; private set; } = new List<Teacher>();

        private School() { } // EF Core

        public School(string name, string logoUrl)
        {
            Id = Guid.NewGuid();
            Name = name;
            LogoUrl = logoUrl;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string logoUrl)
        {
            Name = name;
            LogoUrl = logoUrl;
        }
    }
}