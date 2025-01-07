using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.Weapons;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : Controller
    {
        private readonly IWeaponRepository _repository;
        private readonly IMapper _mapper;

        public WeaponController(IWeaponRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<WeaponDto>))]
        public IActionResult GetWeapons()
        {
            var weapons = _repository.GetWeapons();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<WeaponDto>>(weapons);
            return Ok(mapped);
        }

        [HttpGet("{weaponId}")]
        [ProducesResponseType(200, Type = typeof(WeaponDto))]
        public IActionResult GetWeapon(int id)
        {
            if (!_repository.WeaponExists(id))
                return NotFound();

            var weapon = _repository.GetWeapon(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<WeaponDto>(weapon);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateWeapon([FromBody] WeaponAddEditDto weaponDto)
        {
            if (weaponDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetWeapons()
                .Where(x => x.Name.Trim().ToLower() == weaponDto.Name.Trim().ToLower())
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "Weapon already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Weapon>(weaponDto);
            if (!_repository.CreateWeapon(entity))
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
        public IActionResult UpdateWeapon([FromBody] WeaponAddEditDto weaponDto)
        {
            if (weaponDto == null)
                return BadRequest(ModelState);

            if (!_repository.WeaponExists(weaponDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Weapon>(weaponDto);
            if (!_repository.UpdateWeapon(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{weaponId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWeapon(int weaponId)
        {
            if (!_repository.WeaponExists(weaponId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetWeapon(weaponId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteWeapon(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
