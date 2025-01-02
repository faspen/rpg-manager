using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseStrength = table.Column<int>(type: "int", nullable: false),
                    BaseAgility = table.Column<int>(type: "int", nullable: false),
                    BaseIntelligence = table.Column<int>(type: "int", nullable: false),
                    BaseFaith = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlavorText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    SingleTarget = table.Column<bool>(type: "bit", nullable: false),
                    OverTime = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LevelRequirment = table.Column<int>(type: "int", nullable: false),
                    Unlocked = table.Column<bool>(type: "bit", nullable: false),
                    ArchetypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArchetypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponTypeId = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    StrengthRequirement = table.Column<int>(type: "int", nullable: true),
                    AgilityRequirement = table.Column<int>(type: "int", nullable: true),
                    IntelligenceRequirement = table.Column<int>(type: "int", nullable: true),
                    FaithRequirement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponTypes_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "WeaponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlavorText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    SingleTarget = table.Column<bool>(type: "bit", nullable: false),
                    OverTime = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LevelRequirment = table.Column<int>(type: "int", nullable: false),
                    Unlocked = table.Column<bool>(type: "bit", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialSkills_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Vigor = table.Column<int>(type: "int", nullable: true),
                    Stamina = table.Column<int>(type: "int", nullable: true),
                    Aether = table.Column<int>(type: "int", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: true),
                    Agility = table.Column<int>(type: "int", nullable: true),
                    Intelligence = table.Column<int>(type: "int", nullable: true),
                    Faith = table.Column<int>(type: "int", nullable: true),
                    ArchetypeId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorRating = table.Column<int>(type: "int", nullable: false),
                    ShieldRating = table.Column<int>(type: "int", nullable: false),
                    EvasionRating = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    ArmorType = table.Column<int>(type: "int", nullable: false),
                    StrengthRequirement = table.Column<int>(type: "int", nullable: true),
                    AgilityRequirement = table.Column<int>(type: "int", nullable: true),
                    IntelligenceRequirement = table.Column<int>(type: "int", nullable: true),
                    FaithRequirement = table.Column<int>(type: "int", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armors_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armors_CharacterId",
                table: "Armors",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArchetypeId",
                table: "Characters",
                column: "ArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ArchetypeId",
                table: "Skills",
                column: "ArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_ArchetypeId",
                table: "Specializations",
                column: "ArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialSkills_SpecializationId",
                table: "SpecialSkills",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponTypeId",
                table: "Weapons",
                column: "WeaponTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SpecialSkills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DropTable(
                name: "WeaponTypes");
        }
    }
}
