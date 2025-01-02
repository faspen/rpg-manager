using System.ComponentModel.DataAnnotations;
using RPGManager.Data;
using RPGManager.Dtos.Weapons;

namespace RPGManager.Dtos.WeaponTypes
{
    public class WeaponTypeAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DamageType DamageType { get; set; }
    }
}
