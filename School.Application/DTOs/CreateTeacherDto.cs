using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs
{
    public class CreateTeacherDto
    {
        public string FullName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public Guid SchoolId { get; set; }
    }
}
