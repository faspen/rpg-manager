using System.ComponentModel.DataAnnotations;

namespace RPGManager.Data
{
    public class Archetype
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public int BaseStrength { get; set; }

        [Required]
        public int BaseAgility { get; set; }

        [Required]
        public int BaseIntelligence { get; set; }

        [Required]
        public int BaseFaith { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Specialization> Specializations { get; set; }
    }
}
