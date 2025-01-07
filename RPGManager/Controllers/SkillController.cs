using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.Skills;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillRepository _repository;
        private readonly IMapper _mapper;

        public SkillController(ISkillRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<SkillDto>))]
        public IActionResult GetSkills()
        {
            var skills = _repository.GetSkills();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<SkillDto>>(skills);
            return Ok(mapped);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(200, Type = typeof(SkillDto))]
        public IActionResult GetSkill(int id)
        {
            if (!_repository.SkillExists(id))
                return NotFound();

            var skill = _repository.GetSkill(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<SkillDto>(skill);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSkill([FromBody] SkillAddEditDto skillDto)
        {
            if (skillDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetSkills()
                .Where(x => x.Name.Trim().ToLower() == skillDto.Name.Trim().ToLower())
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "Skill already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Skill>(skillDto);
            if (!_repository.CreateSkill(entity))
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
        public IActionResult UpdateSkill([FromBody] SkillAddEditDto skillDto)
        {
            if (skillDto == null)
                return BadRequest(ModelState);

            if (!_repository.SkillExists(skillDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Skill>(skillDto);
            if (!_repository.UpdateSkill(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSkill(int skillId)
        {
            if (!_repository.SkillExists(skillId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetSkill(skillId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteSkill(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
