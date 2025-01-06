using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface ISpecialSkillRepository
    {
        ICollection<SpecialSkill> GetSpecialSkills();
        SpecialSkill GetSpecialSkill(int specialSkillId);
        bool SpecialSkillExists(int specialSkillId);
        bool CreateSpecialSkill(SpecialSkill specialSkill);
        bool UpdateSpecialSkill(SpecialSkill specialSkill);
        bool DeleteSpecialSkill(SpecialSkill specialSkill);
        bool Save();
    }
}
