using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class SpecialSkillRepository : ISpecialSkillRepository
    {
        private readonly RPGManagerDbContext _context;

        public SpecialSkillRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool CreateSpecialSkill(SpecialSkill specialSkill)
        {
            _context.SpecialSkills.Add(specialSkill);
            return Save();
        }

        public bool DeleteSpecialSkill(SpecialSkill specialSkill)
        {
            _context.SpecialSkills.Remove(specialSkill);
            return Save();
        }

        public SpecialSkill GetSpecialSkill(int specialSkillId)
        {
            return _context.SpecialSkills
                .Include(x => x.Specialization)
                .Where(x => x.Id == specialSkillId)
                .FirstOrDefault();
        }

        public ICollection<SpecialSkill> GetSpecialSkills()
        {
            return _context.SpecialSkills
                .Include(x => x.Specialization)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 1 ? true : false;
        }

        public bool SpecialSkillExists(int specialSkillId)
        {
            return _context.SpecialSkills.Any(x => x.Id == specialSkillId);
        }

        public bool UpdateSpecialSkill(SpecialSkill specialSkill)
        {
            _context.SpecialSkills.Update(specialSkill);
            return Save();
        }
    }
}
