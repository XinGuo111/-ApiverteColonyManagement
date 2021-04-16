using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818119170L),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818119483L),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818159620L),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818159965L),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818107181L),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818107503L),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colony",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818135428L),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818135764L),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    HostId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    HiveNumber = table.Column<int>(type: "integer", nullable: false),
                    ColonyNumber = table.Column<string>(type: "text", nullable: true),
                    ColonySource = table.Column<string>(type: "text", nullable: true),
                    QueenType = table.Column<string>(type: "text", nullable: true),
                    Markings = table.Column<string>(type: "text", nullable: true),
                    GeneticBreed = table.Column<string>(type: "text", nullable: true),
                    InstallationType = table.Column<string>(type: "text", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    InstallDate = table.Column<long>(type: "bigint", nullable: false),
                    HiveType = table.Column<string>(type: "text", nullable: true),
                    BroodChamberType = table.Column<string>(type: "text", nullable: true),
                    QueenExclude = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colony_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colony_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialInspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818012527L),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818045550L),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: true),
                    ColonyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Harvest = table.Column<string[]>(type: "text[]", nullable: true),
                    Feeds = table.Column<string[]>(type: "text[]", nullable: true),
                    Treatments = table.Column<string[]>(type: "text[]", nullable: true),
                    TreatmentDetails = table.Column<string[]>(type: "text[]", nullable: true),
                    Wintering = table.Column<string[]>(type: "text[]", nullable: true),
                    Growth = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialInspection_Colony_ColonyId",
                        column: x => x.ColonyId,
                        principalTable: "Colony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialInspection_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypicalInspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818091876L),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<long>(type: "bigint", nullable: false, defaultValue: 637530607818092256L),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: true),
                    ColonyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weather = table.Column<string[]>(type: "text[]", nullable: true),
                    Population = table.Column<string>(type: "text", nullable: true),
                    Mood = table.Column<string>(type: "text", nullable: true),
                    Fitness = table.Column<string>(type: "text", nullable: true),
                    BroodChambers = table.Column<int>(type: "integer", nullable: false),
                    HoneyChamber = table.Column<int>(type: "integer", nullable: false),
                    MouseGuard = table.Column<bool>(type: "boolean", nullable: false),
                    WaspGuard = table.Column<bool>(type: "boolean", nullable: false),
                    PollenCollector = table.Column<bool>(type: "boolean", nullable: false),
                    HiveBottom = table.Column<string>(type: "text", nullable: true),
                    Vents = table.Column<string>(type: "text", nullable: true),
                    Brood = table.Column<string>(type: "text", nullable: true),
                    Honey = table.Column<string>(type: "text", nullable: true),
                    BroodPattern = table.Column<string>(type: "text", nullable: true),
                    Issues = table.Column<string[]>(type: "text[]", nullable: true),
                    Growth = table.Column<string[]>(type: "text[]", nullable: true),
                    Seasonal = table.Column<string[]>(type: "text[]", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Cells = table.Column<string>(type: "text", nullable: true),
                    SwarmStatus = table.Column<string>(type: "text", nullable: true),
                    Excluder = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypicalInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypicalInspection_Colony_ColonyId",
                        column: x => x.ColonyId,
                        principalTable: "Colony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypicalInspection_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colony_AreaId",
                table: "Colony",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colony_HostId",
                table: "Colony",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInspection_ColonyId",
                table: "SpecialInspection",
                column: "ColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInspection_UserID",
                table: "SpecialInspection",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalInspection_ColonyId",
                table: "TypicalInspection",
                column: "ColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalInspection_UserID",
                table: "TypicalInspection",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialInspection");

            migrationBuilder.DropTable(
                name: "TypicalInspection");

            migrationBuilder.DropTable(
                name: "Colony");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Host");
        }
    }
}
