using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class WeaponTypeRepository : IWeaponTypeRepository
    {
        private readonly RPGManagerDbContext _context;

        public WeaponTypeRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool CreateWeaponType(WeaponType weaponType)
        {
            _context.Add(weaponType);
            return Save();
        }

        public bool DeleteWeaponType(WeaponType weaponType)
        {
            _context.Remove(weaponType);
            return Save();
        }

        public WeaponType GetWeaponType(int weaponTypeId)
        {
            return _context.WeaponTypes
                .Include(x => x.Weapons)
                .Where(x => x.Id == weaponTypeId)
                .FirstOrDefault();
        }

        public ICollection<WeaponType> GetWeaponTypes()
        {
            return _context.WeaponTypes
                .Include(x => x.Weapons)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateWeaponType(WeaponType weaponType)
        {
            _context.Update(weaponType);
            return Save();
        }

        public bool WeaponTypeExists(int weaponTypeId)
        {
            return _context.WeaponTypes.Any(x => x.Id == weaponTypeId);
        }
    }
}
