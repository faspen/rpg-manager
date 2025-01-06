using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface IArmorRepository
    {
        ICollection<Armor> GetArmors();
        Armor GetArmor(int armorId);
        bool ArmorExists(int armorId);
        bool CreateArmor(Armor armor);
        bool UpdateArmor(Armor armor);
        bool DeleteArmor(Armor armor);
        bool Save();
    }
}
