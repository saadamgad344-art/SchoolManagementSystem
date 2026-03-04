using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Application.DTOs;
using School.Infrastructure.Persistence;
using AutoMapper;

namespace School.API.Controllers
{
    //[Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public SchoolsController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDto>>> GetSchools()
        {
            
        
            var schools = await _context.Schools.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SchoolDto>>(schools));
        }

        // GET: api/Schools/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDto>> GetSchool(Guid id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
                return NotFound();

            return Ok(_mapper.Map<SchoolDto>(school));
        }

        // POST: api/Schools
        [HttpPost]
        public async Task<ActionResult<SchoolDto>> CreateSchool(CreateSchoolDto dto)
        {
            
            var school = _mapper.Map<Domain.Entities.School>(dto);

            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            var schoolDto = _mapper.Map<SchoolDto>(school);
            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, schoolDto);
        }

        // PUT: api/Schools/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(Guid id, UpdateSchoolDto dto)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
                return NotFound();

            
            school.Update(dto.Name, dto.LogoUrl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Schools/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
                return NotFound();

           
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}