using System.ComponentModel.DataAnnotations;

namespace RPGManager.Data
{
    public class WeaponType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DamageType DamageType { get; set; }

        public ICollection<Weapon> Weapons { get; set; }
    }
}
