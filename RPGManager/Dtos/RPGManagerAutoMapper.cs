using AutoMapper;
using RPGManager.Data;
using RPGManager.Dtos.Archetypes;
using RPGManager.Dtos.Armors;
using RPGManager.Dtos.Characters;
using RPGManager.Dtos.Skills;
using RPGManager.Dtos.Specializations;
using RPGManager.Dtos.SpecialSkills;
using RPGManager.Dtos.Weapons;
using RPGManager.Dtos.WeaponTypes;

namespace RPGManager.Dtos
{
    public class RPGManagerAutoMapper : Profile
    {
        public RPGManagerAutoMapper()
        {
            CreateMap<Archetype, ArchetypeDto>();
            CreateMap<ArchetypeAddEditDto, Archetype>();

            CreateMap<Armor, ArmorDto>();
            CreateMap<ArmorAddEditDto, Armor>();

            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterAddEditDto, Character>();

            CreateMap<Skill, SkillDto>();
            CreateMap<SkillAddEditDto, Skill>();

            CreateMap<Specialization, SpecializationDto>();
            CreateMap<SpecializationAddEditDto, Specialization>();

            CreateMap<SpecialSkill, SpecialSkillDto>();
            CreateMap<SpecialSkillAddEditDto, SpecialSkill>();

            CreateMap<Weapon, WeaponDto>();
            CreateMap<WeaponAddEditDto, Weapon>();

            CreateMap<WeaponType, WeaponTypeDto>();
            CreateMap<WeaponTypeAddEditDto, WeaponType>();
        }
    }
}
