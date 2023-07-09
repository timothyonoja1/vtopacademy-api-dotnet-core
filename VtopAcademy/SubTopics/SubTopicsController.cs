using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.SubTopics
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTopicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubTopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubTopics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubTopicDTO>>> GetSubTopics()
        {
            return await _context.SubTopics
                .Select(x => SubTopicToDTO(x))
                .ToListAsync();
        }

        // GET: api/SubTopics/TopicID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubTopicDTO>>> GetSubTopic(long id)
        {
            return await _context.SubTopics.Where(p => p.TopicID == id)
                .Select(p => SubTopicToDTO(p)).ToListAsync();
        }

        // POST: api/SubTopics
        [HttpPost]
        public async Task<ActionResult<SubTopicDTO>> PostSubTopic(SubTopicDTO subTopicDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subTopic = new SubTopic
            {
                Name = subTopicDTO.Name,
                Number = subTopicDTO.Number,
                IsFree = subTopicDTO.IsFree,
                TopicID = subTopicDTO.TopicID
            };

            _context.SubTopics.Add(subTopic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                null,
                new { id = subTopic.SubTopicID },
                SubTopicToDTO(subTopic));
        }

        // PUT: api/SubTopics/SubTopicID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubTopic(long id, SubTopicDTO subTopicDTO)
        {
            if (!ModelState.IsValid || id != subTopicDTO.SubTopicID)
            {
                return BadRequest();
            }

            var subTopic = await _context.SubTopics.FindAsync(id);
            if (subTopic == null)
            {
                return NotFound();
            }

            subTopic.Name = subTopicDTO.Name;
            subTopic.Number = subTopicDTO.Number;
            subTopic.IsFree = subTopicDTO.IsFree;
            subTopic.TopicID = subTopic.TopicID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SubTopicExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SubTopics/SubTopicID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubTopic(long subTopicID)
        {
            var subTopic = await _context.SubTopics.FindAsync(subTopicID);
            if (subTopic == null)
            {
                return NotFound();
            }

            _context.SubTopics.Remove(subTopic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubTopicExists(long subTopicID)
        {
            return _context.SubTopics.Any(e => e.SubTopicID == subTopicID);
        }

        private static SubTopicDTO SubTopicToDTO(SubTopic subTopic) =>
           new SubTopicDTO
           {
               Name = subTopic.Name,
               Number = subTopic.Number,
               IsFree = subTopic.IsFree,
               TopicID = subTopic.TopicID
           };
    }
}

