using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationCMS.Data.Migrations
{
    public partial class PageIntID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Pages_PageTitle",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PageTitle",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Pages",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Pages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PageId",
                table: "Sections",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Pages_PageId",
                table: "Sections",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Pages_PageId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PageId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pages");

            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "Sections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Pages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PageTitle",
                table: "Sections",
                column: "PageTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Pages_PageTitle",
                table: "Sections",
                column: "PageTitle",
                principalTable: "Pages",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
