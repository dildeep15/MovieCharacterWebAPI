using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.DTO.FranchiseDTO;
using MovieCharacterAPI.DTO.MovieDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public FranchisesController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all franchise from database
        /// </summary>
        /// <returns>List of FranchiseReadDTO</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchise()
        {
            var franchiseList = await _context.Franchise.ToListAsync();
            
            return _mapper.Map<List<FranchiseReadDTO>>(franchiseList);
        }

        /// <summary>
        /// Get a franchise from database specified by id
        /// </summary>
        /// <param name="id">Franchise Id</param>
        /// <returns>FranchiseReadDTO</returns> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseReadDTO>(franchise);
        }


        /// <summary>
        /// Get list of movies in a franchise specified by id
        /// </summary>
        /// <param name="id">Franchise Id</param>
        /// <returns> List of MovieReadDTO</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetAllMoviesInFranchise(int id)
        {
            Franchise franchise = await _context.Franchise.Include(f => f.Movie).Where(f => f.FranchiseId == id).FirstOrDefaultAsync();
            if (franchise == null)
            {
                return NotFound("No Movie found in franchise");
            }

            foreach (Movie movie in franchise.Movie)
            {
                movie.Franchise = null;
            }

            return _mapper.Map<List<MovieReadDTO>>(franchise.Movie);
        }

        /// <summary>
        /// Get list of characters in a franchise specified by Id
        /// </summary>
        /// <param name="id">Franchise Id</param>
        /// <returns> List of characters</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}/character")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetAllCharactersInFranchise(int id)
        {

            var Characters = await _context.Character.Where(character => character.Movies.Any(movie => movie.FranchiseId == id)).Include(c => c.Movies).ToListAsync();
            if (Characters.Count() == 0)
            {
                return NotFound("No Character found in franchise");
            }

            return _mapper.Map<List<CharacterReadDTO>>(Characters);
        }


        /// <summary>
        /// Update franchise by specific franchise id
        /// </summary>
        /// <param name="id">FranchiseId</param>
        /// <param name="franchiseDTO">FranchiseUpdateDTO</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseUpdateDTO franchiseDTO)
        {
            if (id != franchiseDTO.FranchiseId)
            {
                return BadRequest();
            }
            var franchise = _mapper.Map<Franchise>(franchiseDTO);
            _context.Entry(franchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        /// <summary>
        /// Update list of movies in a franchise specified by id
        /// </summary>
        /// <param name="id">FranchiseId</param>
        /// <param name="movies">List of movies id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int id, List<int> movies)
        {
            Franchise franchise = await _context.Franchise.Include(f => f.Movie).FirstOrDefaultAsync(f => f.FranchiseId == id);
            if (franchise == null)
            {
                return NotFound();
            }

            // clear existing movies from given franchise
            franchise.Movie.Clear();

            foreach (int movieId in movies)
            {
                Movie mov = await _context.Movie.FindAsync(movieId);
                franchise.Movie.Add(mov);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Insert a new franchise in database
        /// </summary>
        /// <param name="franchiseDTO">FranchiseCreateDTO</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<FranchiseReadDTO>> PostFranchise(FranchiseCreateDTO franchiseDTO)
        {
            var franchise = _mapper.Map<Franchise>(franchiseDTO);
            _context.Franchise.Add(franchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.FranchiseId }, franchiseDTO);
        }

        /// <summary>
        /// Delete a franchise from database specified by id
        /// </summary>
        /// <param name="id">FranchiseId</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchise.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }




        /// <summary>
        /// Check if a franchise exists in database specified by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool FranchiseExists(int id)
        {
            return _context.Franchise.Any(e => e.FranchiseId == id);
        }
    }
}
