using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.DTOs;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var movies = await _context.Movies
                .Include(m => m.Director)
                .ToListAsync();

            var result = movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Director = new DirectorDto
                {
                    Name = m.Director.Name,
                    Nationality = m.Director.Nationality
                }
            });

            return Ok(result);
        }

        // GET api/movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = new DirectorDto
                {
                    Name = movie.Director.Name,
                    Nationality = movie.Director.Nationality
                }
            });
        }

        // POST api/movies
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDto dto)
        {
            var director = await _context.Directors
                .FirstOrDefaultAsync(d =>
                    d.Name == dto.Director.Name &&
                    d.Nationality == dto.Director.Nationality);

            if (director == null)
            {
                director = new Director
                {
                    Name = dto.Director.Name,
                    Nationality = dto.Director.Nationality
                };

                _context.Directors.Add(director);
            }

            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Director = director
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMovieDto dto)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.Director.Name = dto.Director.Name;
            movie.Director.Nationality = dto.Director.Nationality;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
