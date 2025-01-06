using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly RPGManagerDbContext _context;

        public WeaponRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool CreateWeapon(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
            return Save();
        }

        public bool DeleteWeapon(Weapon weapon)
        {
            _context.Weapons.Remove(weapon);
            return Save();
        }

        public Weapon GetWeapon(int weaponId)
        {
            return _context.Weapons
                .Include(x => x.WeaponType)
                .Include(x => x.Characters)
                .Where(x => x.Id == weaponId)
                .FirstOrDefault();
        }

        public ICollection<Weapon> GetWeapons()
        {
            return _context.Weapons
                .Include(x => x.WeaponType)
                .Include(x => x.Characters)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 1 ? true : false;
        }

        public bool UpdateWeapon(Weapon weapon)
        {
            _context.Weapons.Update(weapon);
            return Save();
        }

        public bool WeaponExists(int weaponId)
        {
            return _context.Weapons.Any(x => x.Id == weaponId);
        }
    }
}
