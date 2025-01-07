using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.SpecialSkills;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialSkillController : Controller
    {
        private readonly ISpecialSkillRepository _repository;
        private readonly IMapper _mapper;

        public SpecialSkillController(ISpecialSkillRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<SpecialSkillDto>))]
        public IActionResult GetSpecialSkills()
        {
            var specialSkills = _repository.GetSpecialSkills();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<SpecialSkillDto>>(specialSkills);
            return Ok(mapped);
        }

        [HttpGet("{specialSkillId}")]
        [ProducesResponseType(200, Type = typeof(SpecialSkillDto))]
        public IActionResult GetSpecialSkill(int id)
        {
            if (!_repository.SpecialSkillExists(id))
                return NotFound();

            var specialSkill = _repository.GetSpecialSkill(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<SpecialSkillDto>(specialSkill);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSpecialSkill([FromBody] SpecialSkillAddEditDto specialSkillDto)
        {
            if (specialSkillDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetSpecialSkills()
                .Where(x => x.Name.Trim().ToLower() == specialSkillDto.Name.Trim().ToLower())
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "SpecialSkill already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<SpecialSkill>(specialSkillDto);
            if (!_repository.CreateSpecialSkill(entity))
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
        public IActionResult UpdateSpecialSkill([FromBody] SpecialSkillAddEditDto specialSkillDto)
        {
            if (specialSkillDto == null)
                return BadRequest(ModelState);

            if (!_repository.SpecialSkillExists(specialSkillDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<SpecialSkill>(specialSkillDto);
            if (!_repository.UpdateSpecialSkill(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{specialSkillId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSpecialSkill(int specialSkillId)
        {
            if (!_repository.SpecialSkillExists(specialSkillId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetSpecialSkill(specialSkillId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteSpecialSkill(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
