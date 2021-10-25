using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class SeedActorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("31412b61-1020-41fa-9c3d-fc2cd972d5da"), "Bruce", "Willies" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("31412b61-1020-41fa-9c3d-fc2cd972d5db"), "John", "Travolta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("31412b61-1020-41fa-9c3d-fc2cd972d5da"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("31412b61-1020-41fa-9c3d-fc2cd972d5db"));
        }
    }
}
