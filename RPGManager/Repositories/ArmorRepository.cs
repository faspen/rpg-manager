using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class ArmorRepository : IArmorRepository
    {
        private readonly RPGManagerDbContext _context;

        public ArmorRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool ArmorExists(int armorId)
        {
            return _context.Armors.Any(x => x.Id == armorId);
        }

        public bool CreateArmor(Armor armor)
        {
            _context.Armors.Add(armor);
            return Save();
        }

        public bool DeleteArmor(Armor armor)
        {
            _context.Armors.Remove(armor);
            return Save();
        }

        public Armor GetArmor(int armorId)
        {
            return _context.Armors
                .Include(x => x.Character)
                .Where(x => x.Id == armorId)
                .FirstOrDefault();
        }

        public ICollection<Armor> GetArmors()
        {
            return _context.Armors
                .Include(x => x.Character)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 1 ? true : false;
        }

        public bool UpdateArmor(Armor armor)
        {
            _context.Armors.Update(armor);
            return Save();
        }
    }
}
