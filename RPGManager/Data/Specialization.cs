using System.ComponentModel.DataAnnotations;

namespace RPGManager.Data
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int ArchetypeId { get; set; }
        public Archetype Archetype { get; set; }

        public ICollection<SpecialSkill> SpecialSkills { get; set; }
    }
}
