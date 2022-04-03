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
                values: new object[] { 1, "The Full-Stack Web Development Diploma (FSWD) features an interdisciplinary learning environment to prepare you for a career as a web developer.Focusing on emerging web application development tools and technologies,this unique two - year full - time program offers hands - on experience combined with industry projects to equip you for the many opportunities in this fast - growing and high - demand field.", "Full-Stack Web Development" });

            migrationBuilder.InsertData(
                table: "SchoolProgram",
                columns: new[] { "SchoolProgramId", "ProgramDesc", "ProgramName" },
                values: new object[] { 2, "STUDY COMPUTING & INFORMATION TECHNOLOGY COMPUTER INFORMATION TECHNOLOGYComputer Information Technology", "Computer Information Technology" });

            migrationBuilder.InsertData(
                table: "SchoolProgram",
                columns: new[] { "SchoolProgramId", "ProgramDesc", "ProgramName" },
                values: new object[] { 3, "BCIT’s Computer Systems Technology (CST) two-year diploma program combines computer systems theory with hands-on practical experience in software development. You’ll learn software engineering and programming from industry professionals, and gain experience working on real projects, from concept to deployment. In second year, specialty options add depth and further hone your skills.", "Computer Systems Technology" });

            migrationBuilder.InsertData(
                table: "SchoolProgram",
                columns: new[] { "SchoolProgramId", "ProgramDesc", "ProgramName" },
                values: new object[] { 4, "In the Digital Design and Development diploma program at BCIT, you will build a solid foundation in designing, developing, and creating interactive, dynamic, immersive social and online applications across various digital media platforms.Learn to work within a team to design and develop web and mobile applications, educational products, video, and audio assets for interactive media and business applications.", "Digital Design and Development" });

            migrationBuilder.InsertData(
                table: "ProgramRate",
                columns: new[] { "ProgramRateId", "Created_At", "ProgramReview", "RateNumber", "SchoolProgramId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The program have you do video story telling, counting cash flow, and think about ethic issues when you don't even have solid understanding on OOP. This is just ridiculous. For those who are looking to enter this program, think twice.", 1, 1 });

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
