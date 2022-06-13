using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adhira.WebUI.Migrations
{
    public partial class blogpostupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "BlogPosts",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "BlogPosts");
        }
    }
}
