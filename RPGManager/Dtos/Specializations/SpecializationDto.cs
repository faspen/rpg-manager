using RPGManager.Data;
using RPGManager.Dtos.Archetypes;
using RPGManager.Dtos.SpecialSkills;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Specializations
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int ArchetypeId { get; set; }
        public ArchetypeDto Archetype { get; set; }

        public List<SpecialSkillDto> SpecialSkills { get; set; }
    }
}
