using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs
{
    public class CreateSchoolDto
    {
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
    }
}
