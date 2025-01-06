using Microsoft.EntityFrameworkCore;
using RPGManager.Data;
using RPGManager.Interfaces;

namespace RPGManager.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly RPGManagerDbContext _context;

        public SpecializationRepository(RPGManagerDbContext context)
        {
            _context = context;
        }

        public bool CreateSpecialization(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            return Save();
        }

        public bool DeleteSpecialization(Specialization specialization)
        {
            _context.Specializations.Remove(specialization);
            return Save();
        }

        public Specialization GetSpecialization(int specializationId)
        {
            return _context.Specializations
                .Include(x => x.Archetype)
                .Include(x => x.SpecialSkills)
                .Where(x => x.Id == specializationId)
                .FirstOrDefault();
        }

        public ICollection<Specialization> GetSpecializations()
        {
            return _context.Specializations
                .Include(x => x.Archetype)
                .Include(x => x.SpecialSkills)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 1 ? true : false;
        }

        public bool SpecializationExists(int specializationId)
        {
            return _context.Specializations.Any(x => x.Id == specializationId);
        }

        public bool UpdateSpecialization(Specialization specialization)
        {
            _context.Specializations.Update(specialization);
            return Save();
        }
    }
}
