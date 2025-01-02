using RPGManager.Data;
using RPGManager.Dtos.Characters;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Weapons
{
    public class WeaponDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WeaponTypeId { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Damage { get; set; }
        public int Durability { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public Rarity Rarity { get; set; }
        public int? StrengthRequirement { get; set; }
        public int? AgilityRequirement { get; set; }
        public int? IntelligenceRequirement { get; set; }
        public int? FaithRequirement { get; set; }

        public List<CharacterDto> Characters { get; set; }
    }
}
