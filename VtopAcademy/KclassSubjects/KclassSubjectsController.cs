using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.KclassSubjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class KclassSubjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KclassSubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KclassSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KclassSubjectDTO>>> GetKclassSubjects()
        {
            return await _context.KclassSubjects
                .Select(x => KclassSubjectToDTO(x))
                .ToListAsync();
        }

        // GET: api/KclassSubjects/KclassSubjectID
        [HttpGet("{id}")]
        public async Task<ActionResult<KclassSubjectDTO>> GetKclassSubject(long id)
        {
            var todoItem = await _context.KclassSubjects.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return KclassSubjectToDTO(todoItem);
        }

        // POST: api/KclassSubjects
        [HttpPost]
        public async Task<ActionResult<KclassSubjectDTO>> PostTodoItem(KclassSubjectDTO kclassSubjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kclassSubject = new KclassSubject
            {
                KclassID = kclassSubjectDTO.KclassID,
                SubjectID = kclassSubjectDTO.SubjectID
            };

            _context.KclassSubjects.Add(kclassSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetKclassSubject),
                new { id = kclassSubject.KclassSubjectID },
                KclassSubjectToDTO(kclassSubject));
        }

        // PUT: api/KclassSubject/KclassSubjectID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTKclassSubject(long id, KclassSubjectDTO kclassSubjectDTO)
        {
            if (!ModelState.IsValid || id != kclassSubjectDTO.KclassSubjectID)
            {
                return BadRequest();
            }

            var kclassSubject = await _context.KclassSubjects.FindAsync(id);
            if (kclassSubject == null)
            {
                return NotFound();
            }

            kclassSubject.KclassID = kclassSubject.KclassID;
            kclassSubject.SubjectID = kclassSubject.SubjectID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!KclassSubjectExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/KclassSubjects/KclassSubjectID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKclassSubject(long id)
        {
            var kclassSubject = await _context.KclassSubjects.FindAsync(id);
            if (kclassSubject == null)
            {
                return NotFound();
            }

            _context.KclassSubjects.Remove(kclassSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KclassSubjectExists(long kclassSubjectID)
        {
            return _context.KclassSubjects.Any(e => e.KclassSubjectID == kclassSubjectID);
        }

        private static KclassSubjectDTO KclassSubjectToDTO(KclassSubject kclassSubject) =>
           new KclassSubjectDTO
           {
               KclassSubjectID = kclassSubject.KclassSubjectID,
               KclassID = kclassSubject.KclassID,
               SubjectID = kclassSubject.SubjectID
           };
    }

}

