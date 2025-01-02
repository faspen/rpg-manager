using RPGManager.Data;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Characters
{
    public class CharacterAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Sex Sex { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }

        public int Level { get; set; }
        public int Experience { get; set; }

        public int? Vigor { get; set; }
        public int? Stamina { get; set; }
        public int? Aether { get; set; }
        public int? Strength { get; set; }
        public int? Agility { get; set; }
        public int? Intelligence { get; set; }
        public int? Faith { get; set; }

        public int ArchetypeId { get; set; }
        public int WeaponId { get; set; }
    }
}
