using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationCMS.Data.Migrations
{
    public partial class ContentSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentSection",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentSection",
                table: "Pages");
        }
    }
}
