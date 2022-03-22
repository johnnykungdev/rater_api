using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rater_api.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolProgram",
                columns: table => new
                {
                    SchoolProgramId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramName = table.Column<string>(type: "TEXT", nullable: false),
                    ProgramDesc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolProgram", x => x.SchoolProgramId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramRate",
                columns: table => new
                {
                    ProgramRateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramReview = table.Column<string>(type: "TEXT", nullable: false),
                    RateNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_At = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchoolProgramId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramRate", x => x.ProgramRateId);
                    table.ForeignKey(
                        name: "FK_ProgramRate_SchoolProgram_SchoolProgramId",
                        column: x => x.SchoolProgramId,
                        principalTable: "SchoolProgram",
                        principalColumn: "SchoolProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SchoolProgram",
                columns: new[] { "SchoolProgramId", "ProgramDesc", "ProgramName" },
                values: new object[] { 1, "This is FSWD", "FSWD" });

            migrationBuilder.InsertData(
                table: "ProgramRate",
                columns: new[] { "ProgramRateId", "Created_At", "ProgramReview", "RateNumber", "SchoolProgramId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FSWD sucks", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramRate_SchoolProgramId",
                table: "ProgramRate",
                column: "SchoolProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramRate");

            migrationBuilder.DropTable(
                name: "SchoolProgram");
        }
    }
}
