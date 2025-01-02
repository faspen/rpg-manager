using RPGManager.Data;
using RPGManager.Dtos.Characters;
using RPGManager.Dtos.Skills;
using RPGManager.Dtos.Specializations;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Archetypes
{
    public class ArchetypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseStrength { get; set; }
        public int BaseAgility { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseFaith { get; set; }
        public List<CharacterDto> Characters { get; set; }
        public List<SkillDto> Skills { get; set; }
        public List<SpecializationDto> Specializations { get; set; }
    }
}
