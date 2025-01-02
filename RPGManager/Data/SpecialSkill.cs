using System.ComponentModel.DataAnnotations;

namespace RPGManager.Data
{
    public class SpecialSkill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string FlavorText { get; set; }
        public int Damage { get; set; }
        public DamageType DamageType { get; set; }
        public bool SingleTarget { get; set; }
        public bool OverTime { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public int LevelRequirment { get; set; }
        public bool Unlocked { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
