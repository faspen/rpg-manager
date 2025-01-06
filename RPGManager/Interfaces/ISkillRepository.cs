using RPGManager.Data;

namespace RPGManager.Interfaces
{
    public interface ISkillRepository
    {
        ICollection<Skill> GetSkills();
        Skill GetSkill(int skillId);
        bool SkillExists(int skillId);
        bool CreateSkill(Skill skill);
        bool UpdateSkill(Skill skill);
        bool DeleteSkill(Skill skill);
        bool Save();
    }
}
