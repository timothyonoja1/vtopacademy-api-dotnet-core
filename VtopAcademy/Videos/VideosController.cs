using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtopAcademy.Videos
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoDTO>>> GetVideos()
        {
            return await _context.Videos
                .Select(x => VideoToDTO(x))
                .ToListAsync();
        }

        // GET: api/Videos/SubTopicID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VideoDTO>>> GetVideosBy(long id)
        {
            return await _context.Videos.Where(p => p.SubTopicID == id)
                .Select(p => VideoToDTO(p)).ToListAsync();
        }

        // POST: api/Videos
        [HttpPost]
        public async Task<ActionResult<VideoDTO>> PostTodoItem(VideoDTO videoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string quizID = GenerateUniqueHex(24);

            var video = new Video
            {
                QuizID = GenerateUniqueHex(24),
                MainYoutubeID = videoDTO.MainYoutubeID,
                CorrectionYoutubeID = videoDTO.CorrectionYoutubeID,
                IsFree = videoDTO.IsFree,
                SubTopicID = videoDTO.SubTopicID
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "Video",
                new { id = video.VideoID },
                VideoToDTO(video));
        }

        // PUT: api/Videos/SubTopicID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(long id, VideoDTO videoDTO)
        {
            if (!ModelState.IsValid || id != videoDTO.VideoID)
            {
                return BadRequest();
            }

            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            video.QuizID = video.QuizID;
            video.VideoID = videoDTO.VideoID;
            video.MainYoutubeID = videoDTO.MainYoutubeID;
            video.IsFree = videoDTO.IsFree;
            video.CorrectionYoutubeID = videoDTO.CorrectionYoutubeID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!VideoExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Videos/VideoID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string GenerateUniqueHex(int length)
        {
            if (length % 2 != 0)
            {
                throw new ArgumentException("Length must be an even number.");
            }

            int byteLength = length / 2;
            byte[] buffer = new byte[byteLength];
            Guid uniqueGuid = Guid.NewGuid();
            byte[] guidBytes = uniqueGuid.ToByteArray();
            Buffer.BlockCopy(guidBytes, 0, buffer, 0, byteLength);

            string uniqueHex = BitConverter.ToString(buffer).Replace("-", "");

            return uniqueHex;
        }

        private bool VideoExists(long id)
        {
            return _context.Videos.Any(e => e.VideoID == id);
        }

        private static VideoDTO VideoToDTO(Video video) =>
           new VideoDTO
           {
               VideoID = video.VideoID,
               QuizID = video.QuizID,
               MainYoutubeID = video.MainYoutubeID,
               CorrectionYoutubeID = video.CorrectionYoutubeID,
               IsFree = video.IsFree,
               SubTopicID = video.SubTopicID
           };
    }
}

