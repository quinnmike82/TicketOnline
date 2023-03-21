using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketOnline.Data;
using TicketOnline.Model;

namespace TicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MoviesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            
            return await _context.Movies.Include(m => m.Showtimes).ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(string id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutMovie(string id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreate movie)
        {
            Movie movie1 = new Movie() {
                Name = movie.Name,
                Title = movie.Title,
                Director = movie.Director,
                GenreId = movie.GenreId,
                Cast = movie.Cast,
                ReleaseDate = DateOnly.Parse(movie.ReleaseDate),
                RunTime = TimeOnly.Parse(movie.RunTime),
                Adult = movie.Adult,
                Vote_average = movie.Vote_average,
                BackdropPath = movie.BackdropPath,
                Budget = movie.Budget,
                HomePage = movie.HomePage,
                Language = movie.Language,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                PosterPath = movie.PosterPath,
                Revenue = movie.Revenue,
                Status = movie.Status,
                Tagline = movie.Tagline,
                Video = movie.Video,
                Vote_count = movie.Vote_count
            };
            _context.Movies.Add(movie1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie1.Id }, movie1);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(string id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
