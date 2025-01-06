using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface ISpecializationRepository
    {
        ICollection<Specialization> GetSpecializations();
        Specialization GetSpecialization(int specializationId);
        bool SpecializationExists(int specializationId);
        bool CreateSpecialization(Specialization specialization);
        bool UpdateSpecialization(Specialization specialization);
        bool DeleteSpecialization(Specialization specialization);
        bool Save();
    }
}
