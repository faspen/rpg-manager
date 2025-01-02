using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface IArchetypeRepository
    {
        ICollection<Archetype> GetArchetypes();
        Archetype GetArchetype(int archetypeId);
        bool ArchetypeExists(int archetypeId);
        bool CreateArchetype (Archetype archetype);
        bool UpdateArchetype(Archetype archetype);
        bool DeleteArchetype(Archetype archetype);
        bool Save();
    }
}
