﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGManager.Data;

#nullable disable

namespace RPGManager.Migrations
{
    [DbContext(typeof(RPGManagerDbContext))]
    [Migration("20250102161535_Initial-Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RPGManager.Data.Archetype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseAgility")
                        .HasColumnType("int");

                    b.Property<int>("BaseFaith")
                        .HasColumnType("int");

                    b.Property<int>("BaseIntelligence")
                        .HasColumnType("int");

                    b.Property<int>("BaseStrength")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Archetypes");
                });

            modelBuilder.Entity("RPGManager.Data.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgilityRequirement")
                        .HasColumnType("int");

                    b.Property<int>("ArmorRating")
                        .HasColumnType("int");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durability")
                        .HasColumnType("int");

                    b.Property<int>("EvasionRating")
                        .HasColumnType("int");

                    b.Property<int?>("FaithRequirement")
                        .HasColumnType("int");

                    b.Property<int?>("IntelligenceRequirement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<int>("ShieldRating")
                        .HasColumnType("int");

                    b.Property<int?>("StrengthRequirement")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("RPGManager.Data.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Aether")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("ArchetypeId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Faith")
                        .HasColumnType("int");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<int?>("Stamina")
                        .HasColumnType("int");

                    b.Property<int?>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("Vigor")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArchetypeId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("RPGManager.Data.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArchetypeId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlavorText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("LevelRequirment")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OverTime")
                        .HasColumnType("bit");

                    b.Property<bool>("SingleTarget")
                        .HasColumnType("bit");

                    b.Property<bool>("Unlocked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ArchetypeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("RPGManager.Data.SpecialSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlavorText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("LevelRequirment")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OverTime")
                        .HasColumnType("bit");

                    b.Property<bool>("SingleTarget")
                        .HasColumnType("bit");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<bool>("Unlocked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("SpecialSkills");
                });

            modelBuilder.Entity("RPGManager.Data.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArchetypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArchetypeId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("RPGManager.Data.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgilityRequirement")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durability")
                        .HasColumnType("int");

                    b.Property<int?>("FaithRequirement")
                        .HasColumnType("int");

                    b.Property<int?>("IntelligenceRequirement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<int?>("StrengthRequirement")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<int>("WeaponTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeaponTypeId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("RPGManager.Data.WeaponType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeaponTypes");
                });

            modelBuilder.Entity("RPGManager.Data.Armor", b =>
                {
                    b.HasOne("RPGManager.Data.Character", "Character")
                        .WithMany("Armors")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Character");
                });

            modelBuilder.Entity("RPGManager.Data.Character", b =>
                {
                    b.HasOne("RPGManager.Data.Archetype", "Archetype")
                        .WithMany("Characters")
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RPGManager.Data.Weapon", "Weapon")
                        .WithMany("Characters")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Archetype");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("RPGManager.Data.Skill", b =>
                {
                    b.HasOne("RPGManager.Data.Archetype", "Archetype")
                        .WithMany("Skills")
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Archetype");
                });

            modelBuilder.Entity("RPGManager.Data.SpecialSkill", b =>
                {
                    b.HasOne("RPGManager.Data.Specialization", "Specialization")
                        .WithMany("SpecialSkills")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("RPGManager.Data.Specialization", b =>
                {
                    b.HasOne("RPGManager.Data.Archetype", "Archetype")
                        .WithMany("Specializations")
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Archetype");
                });

            modelBuilder.Entity("RPGManager.Data.Weapon", b =>
                {
                    b.HasOne("RPGManager.Data.WeaponType", "WeaponType")
                        .WithMany("Weapons")
                        .HasForeignKey("WeaponTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WeaponType");
                });

            modelBuilder.Entity("RPGManager.Data.Archetype", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Skills");

                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("RPGManager.Data.Character", b =>
                {
                    b.Navigation("Armors");
                });

            modelBuilder.Entity("RPGManager.Data.Specialization", b =>
                {
                    b.Navigation("SpecialSkills");
                });

            modelBuilder.Entity("RPGManager.Data.Weapon", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("RPGManager.Data.WeaponType", b =>
                {
                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
