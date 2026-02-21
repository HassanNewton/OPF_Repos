using AiDemo.Data;
using AiDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace AiDemo.Controllers
{
    [ApiController]
    [Route("api/ollama")]
    public class AiController : ControllerBase
    {
        private readonly AiService _ai;
        private readonly AppDbContext _db;

        public AiController(AiService ai, AppDbContext db)
        {
            _ai = ai;
            _db = db;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] string message)
        {
            var reply = await _ai.AskAsync(message);
            return Ok(reply);
        }

        [HttpPost("summarize")]
        public async Task<IActionResult> Summarize([FromBody] string text)
        {
            var prompt = $"Summarize the following text:\n{text}";
            var result = await _ai.AskAsync(prompt);

            return Ok(result);
        }

        [HttpPost("translate")]
        public async Task<IActionResult> Translate([FromBody] string text)
        {
            var prompt = $"Translate this sentence to Swedish:\n{text}";
            var result = await _ai.AskAsync(prompt);

            return Ok(result);
        }

        [HttpGet("movie-recommendations")]
        public async Task<IActionResult> MovieRecommendations()
        {
            var movies = await _db.UserMovies.ToListAsync();

            var historyText = string.Join("\n",
                movies.Select(m => $"{m.Title} ({m.Genre}) rating: {m.Rating}/5"));

            var prompt = $"""
            A user has watched and rated these movies:

            {historyText}

            Based on their preferences, recommend 5 new movies they would most likely enjoy.
            Return only movie titles.
            """;

            var result = await _ai.AskAsync(prompt);

            return Ok(result);

            //DB → format → prompt → AI → decision
        }
    }
}