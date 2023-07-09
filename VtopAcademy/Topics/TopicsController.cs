using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.Topics
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDTO>>> GetTopics()
        {
            return await _context.Topics
                .Select(x => TopicToDTO(x))
                .ToListAsync();
        }

        // GET: api/Topics/KclassIDSubjectID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TopicDTO>>> GetTopic(string id)
        {
            string[] ids = id.Split('-');
            long kclassID = long.Parse(ids[0]);
            long subjectID = long.Parse(ids[1]);
            if (kclassID == 0)
            {
                return await _context.Topics.Where(p => p.SubjectID == subjectID)
                                    .Select(p => TopicToDTO(p)).ToListAsync();
            }
            return await _context.Topics
                .Where(p => p.KclassID == kclassID && p.SubjectID == subjectID)
                .Select(p => TopicToDTO(p)).ToListAsync();

        }

        // POST: api/Topics
        [HttpPost]
        public async Task<ActionResult<TopicDTO>> PostTopic(TopicDTO topicDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topic = new Topic
            {
                Name = topicDTO.Name,
                Number = topicDTO.Number,
                KclassID = topicDTO.KclassID,
                SubjectID = topicDTO.SubjectID
            };

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                null,
                new { id = topic.TopicID },
                TopicToDTO(topic));
        }

        // PUT: api/Topics/TopicID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(long id, TopicDTO topicDTO)
        {
            if (!ModelState.IsValid || id != topicDTO.TopicID)
            {
                return BadRequest();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            topic.Name = topicDTO.Name;
            topic.Number = topicDTO.Number;
            topic.KclassID = topicDTO.KclassID;
            topic.SubjectID = topicDTO.SubjectID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TopicExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Topics/TopicID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(long id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(long topicID)
        {
            return _context.Topics.Any(e => e.TopicID == topicID);
        }

        private static TopicDTO TopicToDTO(Topic topic) =>
           new TopicDTO
           {
               TopicID = topic.TopicID,
               Name = topic.Name,
               Number = topic.Number,
               KclassID = topic.KclassID,
               SubjectID = topic.SubjectID
           };
    }
}

