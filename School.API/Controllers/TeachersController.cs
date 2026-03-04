using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class TeachersController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public TeachersController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers()
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var teachers = await _context.Teachers
                .Where(t => t.SchoolId == schoolId) 
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(teachers));
        }

        // GET: api/Teachers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetTeacher(Guid id)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null || teacher.SchoolId != schoolId)
                return NotFound();

            return Ok(_mapper.Map<TeacherDto>(teacher));
        }

        // POST: api/Teachers
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> CreateTeacher(CreateTeacherDto dto)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            if (dto.SchoolId != schoolId)
                return Forbid("You can only add teachers to your own school");

            var teacher = _mapper.Map<Teacher>(dto);
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, _mapper.Map<TeacherDto>(teacher));
        }

        // PUT: api/Teachers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(Guid id, CreateTeacherDto dto)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null || teacher.SchoolId != schoolId)
                return NotFound();

            teacher.Update(dto.FullName, dto.Subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Teachers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            var schoolId = Guid.Parse(User.FindFirst("SchoolId")!.Value);

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null || teacher.SchoolId != schoolId)
                return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}