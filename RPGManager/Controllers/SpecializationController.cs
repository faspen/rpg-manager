using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGManager.Data;
using RPGManager.Dtos.Specializations;
using RPGManager.Interfaces;

namespace RPGManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : Controller
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;

        public SpecializationController(ISpecializationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<SpecializationDto>))]
        public IActionResult GetSpecializations()
        {
            var specializations = _repository.GetSpecializations();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<List<SpecializationDto>>(specializations);
            return Ok(mapped);
        }

        [HttpGet("{specializationId}")]
        [ProducesResponseType(200, Type = typeof(SpecializationDto))]
        public IActionResult GetSpecialization(int id)
        {
            if (!_repository.SpecializationExists(id))
                return NotFound();

            var specialization = _repository.GetSpecialization(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<SpecializationDto>(specialization);
            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSpecialization([FromBody] SpecializationAddEditDto specializationDto)
        {
            if (specializationDto == null)
                return BadRequest(ModelState);

            var existing = _repository.GetSpecializations()
                .Where(x => x.Name.Trim().ToLower() == specializationDto.Name.Trim().ToLower() && x.ArchetypeId == specializationDto.ArchetypeId)
                .FirstOrDefault();

            if (existing != null)
            {
                ModelState.AddModelError("", "Specialization already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Specialization>(specializationDto);
            if (!_repository.CreateSpecialization(entity))
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
        public IActionResult UpdateSpecialization([FromBody] SpecializationAddEditDto specializationDto)
        {
            if (specializationDto == null)
                return BadRequest(ModelState);

            if (!_repository.SpecializationExists(specializationDto.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Specialization>(specializationDto);
            if (!_repository.UpdateSpecialization(entity))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete("{specializationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSpecialization(int specializationId)
        {
            if (!_repository.SpecializationExists(specializationId))
                return BadRequest(ModelState);

            var entityToDelete = _repository.GetSpecialization(specializationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.DeleteSpecialization(entityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
