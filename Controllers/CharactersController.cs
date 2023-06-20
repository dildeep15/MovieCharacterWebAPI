using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class CharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly  IMapper _mapper;

        public CharactersController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all characters from database
        /// </summary>
        /// <returns>List of CharacterReadDTO</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacter()
        {
            var characterList = await _context.Character.ToListAsync();
            return _mapper.Map<List<CharacterReadDTO>>(characterList);
        }

        /// <summary>
        /// Get a character from database specified by id
        /// </summary>
        /// <param name="id">Character Id</param>
        /// <returns>CharacterReadDTO</returns> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var character = await _context.Character.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return _mapper.Map<CharacterReadDTO>(character);
        }

        /// <summary>
        /// Update a character in database specified by Id
        /// </summary>
        /// <param name="id"> Id of character to be updated</param>
        /// <param name="characterDTO"> Character DTO</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterUpdateDTO characterDTO)
        {
            if (id != characterDTO.CharacterId)
            {
                return BadRequest();
            }
            var character = _mapper.Map<Character>(characterDTO);
            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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
        /// Insert a new character in database
        /// </summary>
        /// <param name="characterDTO"> CharacterCreateDTO </param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<CharacterReadDTO>> PostCharacter(CharacterCreateDTO characterDTO)
        {
            var characterModel = _mapper.Map<Character>(characterDTO);
            _context.Character.Add(characterModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = characterModel.CharacterId }, characterDTO);
        }

        /// <summary>
        /// Delete a character from database specified by Id
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Character.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check If a character exists by character Id
        /// </summary>
        /// <param name="id"> Id of character</param>
        /// <returns> boolean</returns>
        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.CharacterId == id);
        }
    }
}
