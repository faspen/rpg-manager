using Microsoft.EntityFrameworkCore;

namespace RPGManager.Data
{
    public class RPGManagerDbContext : DbContext
    {

        public RPGManagerDbContext(DbContextOptions<RPGManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SpecialSkill> SpecialSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weapon>()
                .HasOne(x => x.WeaponType)
                .WithMany(x => x.Weapons)
                .HasForeignKey(x => x.WeaponTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(x => x.Archetype)
                .WithMany(x => x.Characters)
                .HasForeignKey(x => x.ArchetypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(x => x.Weapon)
                .WithMany(x => x.Characters)
                .HasForeignKey(x => x.WeaponId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Armor>()
                .HasOne(x => x.Character)
                .WithMany(x => x.Armors)
                .HasForeignKey(x => x.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Specialization>()
                .HasOne(x => x.Archetype)
                .WithMany(x => x.Specializations)
                .HasForeignKey(x => x.ArchetypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasOne(x => x.Archetype)
                .WithMany(x => x.Skills)
                .HasForeignKey(x => x.ArchetypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpecialSkill>()
                .HasOne(x => x.Specialization)
                .WithMany(x => x.SpecialSkills)
                .HasForeignKey(x => x.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
