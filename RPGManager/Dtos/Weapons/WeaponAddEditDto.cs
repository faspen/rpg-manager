using RPGManager.Data;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Weapons
{
    public class WeaponAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int WeaponTypeId { get; set; }

        public int Damage { get; set; }
        public int Durability { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public Rarity Rarity { get; set; }

        public int? StrengthRequirement { get; set; }
        public int? AgilityRequirement { get; set; }
        public int? IntelligenceRequirement { get; set; }
        public int? FaithRequirement { get; set; }
    }
}
