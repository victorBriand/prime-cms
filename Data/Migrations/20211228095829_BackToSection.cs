using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationCMS.Data.Migrations
{
    public partial class BackToSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "ContentSection",
                table: "Pages",
                newName: "Section");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Section",
                table: "Pages",
                newName: "ContentSection");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
