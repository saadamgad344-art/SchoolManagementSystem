using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs
{
    public class CreateGradeDto
    {
        public Guid StudentId { get; set; }
        public string Subject { get; set; } = null!;
        public double Score { get; set; }
    }
}
