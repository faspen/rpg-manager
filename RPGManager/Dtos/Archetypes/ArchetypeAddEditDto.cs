using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Archetypes
{
    public class ArchetypeAddEditDto
    {
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
    }
}
