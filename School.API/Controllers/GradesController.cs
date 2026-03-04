using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Application.DTOs;
using School.Domain.Entities;
using School.Infrastructure.Persistence;

namespace School.API.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public GradesController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGrades()
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var grades = await _context.Grades
                .Where(g => g.SchoolId == schoolId)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<GradeDto>>(grades));
        }

        // GET: api/Grades/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetGrade(Guid id)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null || grade.SchoolId != schoolId)
                return NotFound();

            return Ok(_mapper.Map<GradeDto>(grade));
        }

        // POST: api/Grades
        [HttpPost]
        public async Task<ActionResult<GradeDto>> CreateGrade(CreateGradeDto dto)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            
            var student = await _context.Students.FindAsync(dto.StudentId);
            if (student == null || student.SchoolId != schoolId)
                return Forbid("Student does not belong to your school");

            var grade = new Grade(dto.StudentId, dto.Subject, dto.Score, schoolId);

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<GradeDto>(grade));
        }

        // PUT: api/Grades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(Guid id, CreateGradeDto dto)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null || grade.SchoolId != schoolId)
                return NotFound();

            grade.Update(dto.Subject, dto.Score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Grades/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(Guid id)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null || grade.SchoolId != schoolId)
                return NotFound();

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
