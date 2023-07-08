using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.exams
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDTO>>> GetExams()
        {
            return await _context.Exams
                .Select(x => ExamToDTO(x))
                .ToListAsync();
        } 

        // GET: api/Exams/SchoolID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExamDTO>>> GetExam(long id)
        {
            return await _context.Exams.Where(p => p.SchoolID == id)
                 .Select(p => ExamToDTO(p)).ToListAsync();
        }

        // POST: api/Exams
        [HttpPost]
        public async Task<ActionResult<ExamDTO>> PostExam(ExamDTO examDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exam = new Exam
            {
                Name = examDTO.Name,
                Number = examDTO.Number,
                SchoolID = examDTO.SchoolID
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "Exam",
                new { id = exam.ExamID },
                ExamToDTO(exam));
        }

        // PUT: api/Exams/ExamID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(long id, ExamDTO examDTO)
        {
            if (!ModelState.IsValid || id != examDTO.ExamID)
            {
                return BadRequest();
            }

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            exam.Name = exam.Name;
            exam.Number = exam.Number;
            exam.SchoolID = exam.SchoolID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ExamExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Exams/ExamID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(long examID)
        {
            return _context.Exams.Any(e => e.ExamID == examID);
        }

        private static ExamDTO ExamToDTO(Exam exam) =>
           new ExamDTO
           {
               ExamID = exam.ExamID,
               Name = exam.Name,
               Number = exam.Number,
               SchoolID = exam.SchoolID
           };
    }
}

