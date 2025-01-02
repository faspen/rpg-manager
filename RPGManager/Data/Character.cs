using System.ComponentModel.DataAnnotations;

namespace RPGManager.Data
{
    public class Character
    {
        [Key]
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

        //Database trigger will set the attributes on create/update
        public int? Vigor { get; set; }
        public int? Stamina { get; set; }
        public int? Aether { get; set; }
        public int? Strength { get; set; }
        public int? Agility { get; set; }
        public int? Intelligence { get; set; }
        public int? Faith { get; set; }

        public int ArchetypeId { get; set; }
        public Archetype Archetype { get; set; }

        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }

        public ICollection<Armor> Armors { get; set; }
    }
}
