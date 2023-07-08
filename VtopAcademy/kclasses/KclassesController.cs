using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.kclasses
{
    [Route("api/[controller]")]
    [ApiController]
    public class KclassesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KclassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Kclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KclassDTO>>> GetKclasses()
        {
            return await _context.Kclasses
                .Select(x => KclassToDTO(x))
                .ToListAsync();
        }

        // GET: api/Kclasses/SchoolID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<KclassDTO>>> GetKclass(long id)
        {
            return await _context.Kclasses.Where(p => p.SchoolID == id)
                .Select(p => KclassToDTO(p)).ToListAsync();
        }

        // POST: api/
        [HttpPost]
        public async Task<ActionResult<KclassDTO>> PostKclass(KclassDTO kclassDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kclass = new Kclass
            {
                Name = kclassDTO.Name,
                Number = kclassDTO.Number,
                SchoolID = kclassDTO.SchoolID
            };

            _context.Kclasses.Add(kclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                null,
                new { id = kclass.KclassId },
                KclassToDTO(kclass));
        }

        // PUT: api/Kclases/kclassID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKclass(long id, KclassDTO kclassDTO)
        {
            if (!ModelState.IsValid || id != kclassDTO.KclassId)
            {
                return BadRequest();
            }

            var kclass = await _context.Kclasses.FindAsync(id);
            if (kclass == null)
            {
                return NotFound();
            }

            kclass.Name = kclassDTO.Name;
            kclass.Number = kclassDTO.Number;
            kclass.SchoolID = kclassDTO.SchoolID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!KclassExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Kclasses/KclassID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKclass(long id)
        {
            var kclass = await _context.Kclasses.FindAsync(id);
            if (kclass == null)
            {
                return NotFound();
            }

            _context.Kclasses.Remove(kclass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KclassExists(long kclassID)
        {
            return _context.Kclasses.Any(e => e.KclassId == kclassID);
        }

        private static KclassDTO KclassToDTO(Kclass kclass) =>
           new KclassDTO
           {
               KclassId = kclass.KclassId,
               Name = kclass.Name,
               Number = kclass.Number,
               SchoolID = kclass.SchoolID
           };
    }
}

