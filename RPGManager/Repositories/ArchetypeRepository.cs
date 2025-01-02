using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class ArchetypeRepository : IArchetypeRepository
    {
        private readonly RPGManagerDbContext _context;

        public ArchetypeRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool ArchetypeExists(int archetypeId)
        {
            return _context.Archetypes.Any(x => x.Id == archetypeId);
        }

        public bool CreateArchetype(Archetype archetype)
        {
            _context.Archetypes.Add(archetype);
            return Save();
        }

        public bool DeleteArchetype(Archetype archetype)
        {
            _context.Archetypes.Remove(archetype);
            return Save();
        }

        public Archetype GetArchetype(int archetypeId)
        {
            return _context.Archetypes
                .Include(x => x.Characters)
                .Where(x => x.Id == archetypeId)
                .FirstOrDefault();
        }

        public ICollection<Archetype> GetArchetypes()
        {
            return _context.Archetypes
                .Include(x => x.Characters)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateArchetype(Archetype archetype)
        {
            _context.Update(archetype);
            return Save();
        }
    }
}
