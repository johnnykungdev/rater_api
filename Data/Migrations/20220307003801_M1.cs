using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rater_api.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolPrograms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ProgramName = table.Column<string>(type: "TEXT", nullable: false),
                    ProgramDesc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPrograms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SchoolPrograms",
                columns: new[] { "Id", "ProgramDesc", "ProgramName" },
                values: new object[] { "qwiqwlkht", "This is the program for web full stack", "Full Stack Web Development" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolPrograms");
        }
    }
}
