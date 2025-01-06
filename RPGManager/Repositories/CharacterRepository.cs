using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly RPGManagerDbContext _context;
        public CharacterRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool CharacterExists(int characterId)
        {
            return _context.Characters.Any(x => x.Id == characterId);
        }

        public bool CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            return Save();
        }

        public bool DeleteCharacter(Character character)
        {
            _context.Characters.Remove(character);
            return Save();
        }

        public Character GetCharacter(int characterId)
        {
            return _context.Characters
                .Include(x => x.Archetype)
                .Include(x => x.Weapon)
                .Include(x => x.Armors)
                .Where(x => x.Id == characterId)
                .FirstOrDefault();
        }

        public ICollection<Character> GetCharacters()
        {
            return _context.Characters
                .Include(x => x.Archetype)
                .Include(x => x.Weapon)
                .Include(x => x.Armors)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 1 ? true : false;
        }

        public bool UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
            return Save();
        }
    }
}
