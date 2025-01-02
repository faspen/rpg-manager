using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface IWeaponTypeRepository
    {
        ICollection<WeaponType> GetWeaponTypes();
        WeaponType GetWeaponType(int weaponTypeId);
        bool WeaponTypeExists(int weaponTypeId);
        bool CreateWeaponType(WeaponType weaponType);
        bool UpdateWeaponType(WeaponType weaponType);
        bool DeleteWeaponType(WeaponType weaponType);
        bool Save();
    }
}
