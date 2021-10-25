using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FunWithEntityFramework.Migrations
{
    public partial class RemovedBirthDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
