using Microsoft.EntityFrameworkCore.Migrations;

namespace Adhira.WebUI.Migrations
{
    public partial class blogpostupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublishedById",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedById",
                table: "BlogPosts");
        }
    }
}
