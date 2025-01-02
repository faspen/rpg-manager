using RPGManager.Data;
using RPGManager.Dtos.Weapons;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.WeaponTypes
{
    public class WeaponTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DamageType DamageType { get; set; }
        public List<WeaponDto> Weapons { get; set; }
    }
}
