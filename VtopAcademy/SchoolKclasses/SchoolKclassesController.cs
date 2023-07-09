using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.SchoolKclasses
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolKclassesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolKclassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolKclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolKclassDTO>>> GetSchoolKclasses()
        {
            return await _context.SchoolKclasses
                .Select(x => SchoolKclassToDTO(x))
                .ToListAsync();
        }

        // GET: api/SchoolKclasses/SchoolKclassID
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolKclassDTO>> GetSchoolKclass(long id)
        {
            var schoolKclass = await _context.SchoolKclasses.FindAsync(id);

            if (schoolKclass == null)
            {
                return NotFound();
            }

            return SchoolKclassToDTO(schoolKclass);
        }

        // POST: api/SchoolKclasses
        [HttpPost]
        public async Task<ActionResult<SchoolKclassDTO>> PostSchoolKclass(SchoolKclassDTO schoolKclassDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schoolKclass = new SchoolKclass
            {
                SchoolID = schoolKclassDTO.SchoolID,
                KclassID = schoolKclassDTO.KclassID
            };

            _context.SchoolKclasses.Add(schoolKclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSchoolKclass),
                new { id = schoolKclass.SchoolKclassID },
                SchoolKclassToDTO(schoolKclass));
        }

        // PUT: api/SchoolKclasses/SchoolKclassID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolKclass(long id, SchoolKclassDTO schoolKclassDTO)
        {
            if (!ModelState.IsValid || id != schoolKclassDTO.SchoolKclassID)
            {
                return BadRequest();
            }

            var schoolKclass = await _context.SchoolKclasses.FindAsync(id);
            if (schoolKclass == null)
            {
                return NotFound();
            }

            schoolKclass.SchoolID = schoolKclassDTO.SchoolID;
            schoolKclass.KclassID = schoolKclassDTO.KclassID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SchoolKclassExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SchoolKclasses/SchoolKclassID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolKclass(long id)
        {
            var schoolKclass = await _context.SchoolKclasses.FindAsync(id);
            if (schoolKclass == null)
            {
                return NotFound();
            }

            _context.SchoolKclasses.Remove(schoolKclass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolKclassExists(long schoolKclassID)
        {
            return _context.SchoolKclasses.Any(e => e.SchoolKclassID == schoolKclassID);
        }

        private static SchoolKclassDTO SchoolKclassToDTO(SchoolKclass schoolKclass) =>
           new SchoolKclassDTO
           {
               SchoolKclassID = schoolKclass.SchoolKclassID,
               SchoolID = schoolKclass.SchoolID,
               KclassID = schoolKclass.KclassID
           };
    }
}

