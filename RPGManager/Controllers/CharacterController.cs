using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.Characters;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _repository;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CharacterDto>))]
        public IActionResult GetCharacters()
        {
            var characters = _repository.GetCharacters();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<CharacterDto>>(characters);
            return Ok(mapped);
        }

        [HttpGet("{characterId}")]
        [ProducesResponseType(200, Type = typeof(CharacterDto))]
        public IActionResult GetCharacter(int id)
        {
            if (!_repository.CharacterExists(id))
                return NotFound();

            var character = _repository.GetCharacter(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<CharacterDto>(character);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCharacter([FromBody] CharacterAddEditDto characterDto)
        {
            if (characterDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetCharacters()
                .Where(x => x.Name.Trim().ToLower() == characterDto.Name.Trim().ToLower())
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "Character already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Character>(characterDto);
            if (!_repository.CreateCharacter(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCharacter([FromBody] CharacterAddEditDto characterDto)
        {
            if (characterDto == null)
                return BadRequest(ModelState);

            if (!_repository.CharacterExists(characterDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Character>(characterDto);
            if (!_repository.UpdateCharacter(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{characterId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCharacter(int characterId)
        {
            if (!_repository.CharacterExists(characterId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetCharacter(characterId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteCharacter(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
