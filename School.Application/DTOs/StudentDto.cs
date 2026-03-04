using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs

    
    {
        public class StudentDto
        {
            public Guid Id { get; set; }
            public string FullName { get; set; } = null!;
            public DateTime DateOfBirth { get; set; }
            public Guid SchoolId { get; set; }
        }
    }
