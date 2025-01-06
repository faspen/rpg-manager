using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface IWeaponRepository
    {
        ICollection<Weapon> GetWeapons();
        Weapon GetWeapon(int weaponId);
        bool WeaponExists(int weaponId);
        bool CreateWeapon(Weapon weapon);
        bool UpdateWeapon(Weapon weapon);
        bool DeleteWeapon(Weapon weapon);
        bool Save();
    }
}
