using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.Archetypes;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchetypeController : Controller
    {
        private readonly IArchetypeRepository _repository;
        private readonly IMapper _mapper;

        public ArchetypeController(IArchetypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ArchetypeDto>))]
        public IActionResult GetArchetypes()
        {
            var characters = _repository.GetArchetypes();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<ArchetypeDto>>(characters);
            return Ok(mapped);
        }

        [HttpGet("{archetypeId}")]
        [ProducesResponseType(200, Type = typeof(ArchetypeDto))]
        public IActionResult GetArchetype(int archetypeId)
        {
            var exists = _repository.ArchetypeExists(archetypeId);

            if (!exists)
                return NotFound();

            var archetype = _repository.GetArchetype(archetypeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<ArchetypeDto>(archetype);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArchetype([FromBody] ArchetypeAddEditDto archetypeDto)
        {
            if (archetypeDto == null)
                return BadRequest(ModelState);

            var archetype = _repository.GetArchetypes()
                .Where(x => x.Name.Trim().ToLower() == archetypeDto.Name.Trim().ToLower())
                .FirstOrDefault();

            if (archetype != null)
            {
                ModelState.AddModelError("", "Archetype already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Archetype>(archetypeDto);
            if (!_repository.CreateArchetype(entity))
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
        public IActionResult UpdateArchetype([FromBody] ArchetypeAddEditDto archetypeDto)
        {
            if (archetypeDto == null)
                return BadRequest(ModelState);

            if (!_repository.ArchetypeExists(archetypeDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Archetype>(archetypeDto);
            if (!_repository.UpdateArchetype(entity))
            {
                ModelState.AddModelError("", "Something went wrong while updating.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{archetypeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteArchetype(int archetypeId)
        {
            if (!_repository.ArchetypeExists(archetypeId))
                return NotFound();

            var entityToDelete = _repository.GetArchetype(archetypeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteArchetype(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
