﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.DTO.MovieDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all movies from database
        /// </summary>
        /// <returns>List of MovieReadDTO</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovie()
        {
            var movieList = await _context.Movie.ToListAsync();
            return _mapper.Map<List<MovieReadDTO>>(movieList);
        }

        /// <summary>
        /// Get a movie from database specified by Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>MovieReadDTO</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieReadDTO>(movie);
        }

        /// <summary>
        /// Update a movie in database specified by id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="movieDTO">MovieUpdateDTO</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO movieDTO)
        {
            if (id != movieDTO.MovieId)
            {
                return BadRequest();
            }
            var movie = _mapper.Map<Movie>(movieDTO);
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

        /// <summary>
        /// Insert a new movie in database
        /// </summary>
        /// <param name="movieDTO">MovieCreateDTO</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<MovieCreateDTO>> PostMovie(MovieCreateDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movieDTO);
        }

        /// <summary>
        /// Delete a movie from database specified by Id
        /// </summary>
        /// <param name="id">MovieId</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Update list of characters in a movie specified by id
        /// </summary>
        /// <param name="id">movie id</param>
        /// <param name="characters"> List of character id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateCharactersInMovie(int id, List<int> characters)
        {
            // get movie object including its character
            Movie movie = await _context.Movie.Include(m => m.Characters).FirstOrDefaultAsync(f => f.MovieId == id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }

            //Clear existing characters in movie
            movie.Characters.Clear();

            foreach(int charId in characters)
            { 
                Character character = await _context.Character.FindAsync(charId);
                movie.Characters.Add(character);
            }

            await _context.SaveChangesAsync();

            return NoContent();

        }


        /// <summary>
        /// Get all characters in a movie specified by id
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <returns>List of characters</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetAllCharactersInMovie(int id)
        {
            //await _context.Character.Where(character => character.Movies.Any(movie => movie.MovieId == id)).ToListAsync();
            var characterList =  await _context.Character.Where(character => character.Movies.Any(movie => movie.MovieId == id)).ToListAsync();
            if (characterList.Count() == 0)
            {
                return NotFound("No character found in specific movie");
            }
            return _mapper.Map<List<CharacterReadDTO>>(characterList);
        }

        /// <summary>
        /// Check if movie exists specified by movie id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }
    }
}
