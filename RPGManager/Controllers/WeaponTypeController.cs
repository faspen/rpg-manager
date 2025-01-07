using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.WeaponTypes;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponTypeController : Controller
    {
        private readonly IWeaponTypeRepository _repository;
        private readonly IMapper _mapper;

        public WeaponTypeController(IWeaponTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<WeaponTypeDto>))]
        public IActionResult GetWeaponTypes()
        {
            var weaponTypes = _repository.GetWeaponTypes();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<WeaponTypeDto>>(weaponTypes);
            return Ok(mapped);
        }

        [HttpGet("{weaponTypeId}")]
        [ProducesResponseType(200, Type = typeof(WeaponTypeDto))]
        public IActionResult GetWeaponType(int id)
        {
            if (!_repository.WeaponTypeExists(id))
                return NotFound();

            var weaponType = _repository.GetWeaponType(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<WeaponTypeDto>(weaponType);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateWeaponType([FromBody] WeaponTypeAddEditDto weaponTypeDto)
        {
            if (weaponTypeDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetWeaponTypes()
                .Where(x => x.Name.Trim().ToLower() == weaponTypeDto.Name.Trim().ToLower())
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "WeaponType already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<WeaponType>(weaponTypeDto);
            if (!_repository.CreateWeaponType(entity))
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
        public IActionResult UpdateWeaponType([FromBody] WeaponTypeAddEditDto weaponTypeDto)
        {
            if (weaponTypeDto == null)
                return BadRequest(ModelState);

            if (!_repository.WeaponTypeExists(weaponTypeDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<WeaponType>(weaponTypeDto);
            if (!_repository.UpdateWeaponType(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{weaponTypeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWeaponType(int weaponTypeId)
        {
            if (!_repository.WeaponTypeExists(weaponTypeId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetWeaponType(weaponTypeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteWeaponType(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
