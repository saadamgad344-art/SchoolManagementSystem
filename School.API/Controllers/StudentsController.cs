using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Application.DTOs;
using School.Domain.Entities;
using School.Infrastructure.Persistence;

namespace School.API.Controllers
{
    [Authorize] // 🔒 كل العمليات محتاجة JWT
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var students = await _context.Students
                .Where(s => s.SchoolId == schoolId) // 🔹 بيانات المدرسة فقط
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        // GET: api/Students/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var student = await _context.Students.FindAsync(id);
            if (student == null || student.SchoolId != schoolId)
                return NotFound();

            return Ok(_mapper.Map<StudentDto>(student));
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentDto dto)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            if (dto.SchoolId != schoolId)
                return Forbid("You can only add students to your own school");

            var student = _mapper.Map<Student>(dto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, _mapper.Map<StudentDto>(student));
        }

        // PUT: api/Students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, CreateStudentDto dto)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var student = await _context.Students.FindAsync(id);
            if (student == null || student.SchoolId != schoolId)
                return NotFound();

            student.Update(dto.FullName, dto.DateOfBirth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var student = await _context.Students.FindAsync(id);
            if (student == null || student.SchoolId != schoolId)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}