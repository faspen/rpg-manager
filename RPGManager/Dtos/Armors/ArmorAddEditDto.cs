using RPGManager.Data;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Armors
{
    public class ArmorAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public int ArmorRating { get; set; }
        public int ShieldRating { get; set; }
        public int EvasionRating { get; set; }
        public int Durability { get; set; }
        public int Value { get; set; }
        public Rarity Rarity { get; set; }
        public ArmorType ArmorType { get; set; }
        public int? StrengthRequirement { get; set; }
        public int? AgilityRequirement { get; set; }
        public int? IntelligenceRequirement { get; set; }
        public int? FaithRequirement { get; set; }

        public int? CharacterId { get; set; }
    }
}
