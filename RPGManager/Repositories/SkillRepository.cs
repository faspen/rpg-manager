using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly RPGManagerDbContext _context;

        public SkillRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            return Save();
        }

        public bool DeleteSkill(Skill skill)
        {
            _context.Skills.Remove(skill);
            return Save();
        }

        public Skill GetSkill(int skillId)
        {
            return _context.Skills
                .Include(x => x.Archetype)
                .Where(x => x.Id == skillId)
                .FirstOrDefault();
        }

        public ICollection<Skill> GetSkills()
        {
            return _context.Skills
                .Include(x => x.Archetype)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 1 ? true : false;
        }

        public bool SkillExists(int skillId)
        {
            return _context.Skills.Any(x => x.Id == skillId);
        }

        public bool UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            return Save();
        }
    }
}
