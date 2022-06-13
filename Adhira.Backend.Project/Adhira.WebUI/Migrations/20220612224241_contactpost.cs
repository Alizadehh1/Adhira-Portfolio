using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adhira.WebUI.Migrations
{
    public partial class contactpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "ContactPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswerByUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnsweredDate",
                table: "ContactPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ContactPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ContactPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ContactPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContactPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "AnswerByUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "AnsweredDate",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContactPosts");
        }
    }
}
