using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.Armors;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorController : Controller
    {
        private readonly IArmorRepository _repository;
        private readonly IMapper _mapper;

        public ArmorController(IArmorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ArmorDto>))]
        public IActionResult GetArmors()
        {
            var armors = _repository.GetArmors();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<ArmorDto>>(armors);
            return Ok(mapped);
        }

        [HttpGet("{armorId}")]
        [ProducesResponseType(200, Type = typeof(ArmorDto))]
        public IActionResult GetArmor(int id)
        {
            if (!_repository.ArmorExists(id))
                return NotFound();

            var armor = _repository.GetArmor(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<ArmorDto>(armor);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArmor([FromBody] ArmorAddEditDto armorDto)
        {
            if (armorDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetArmors()
                .Where(x => x.Name.Trim().ToLower() == armorDto.Name.Trim().ToLower() && x.ArmorType == armorDto.ArmorType && x.Rarity == armorDto.Rarity)
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "Armor already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Armor>(armorDto);
            if (!_repository.CreateArmor(entity))
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
        public IActionResult UpdateArmor([FromBody] ArmorAddEditDto armorDto)
        {
            if (armorDto == null)
                return BadRequest(ModelState);

            if (!_repository.ArmorExists(armorDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Armor>(armorDto);
            if (!_repository.UpdateArmor(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{armorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteArmor(int armorId)
        {
            if (!_repository.ArmorExists(armorId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetArmor(armorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteArmor(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
