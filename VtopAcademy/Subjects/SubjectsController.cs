using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VtopAcademy.Subjects;

namespace VtopAcademy.Subjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetSubjects()
        {
            return await _context.Subjects
                .Select(x => SubjectToDTO(x))
                .ToListAsync();
        }

        // GET: api/Subjects/SchoolID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetSubject(long id)
        {
            return await _context.Subjects.Where(p => p.SchoolID == id)
                .Select(p => SubjectToDTO(p)).ToListAsync();
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<SubjectDTO>> PostSubject(SubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subject = new Subject
            {
                Name = subjectDTO.Name,
                Number = subjectDTO.Number,
                SchoolID = subjectDTO.SchoolID
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                null,
                new { id = subject.SubjectID },
                SubjectToDTO(subject));
        }

        // PUT: api/Subjects/SubjectID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, SubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid || id != subjectDTO.SubjectID)
            {
                return BadRequest();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            subject.Name = subjectDTO.Name;
            subject.Number = subjectDTO.Number;
            subject.SchoolID = subjectDTO.SchoolID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Subjects/SubjectID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long subjectID)
        {
            return _context.Subjects.Any(e => e.SubjectID == subjectID);
        }

        private static SubjectDTO SubjectToDTO(Subject subject) =>
           new SubjectDTO
           {
               SubjectID = subject.SubjectID,
               Name = subject.Name,
               Number = subject.Number,
               SchoolID = subject.SchoolID
           };
    }
}

