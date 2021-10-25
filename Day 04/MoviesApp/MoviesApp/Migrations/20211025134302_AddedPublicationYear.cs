using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class AddedPublicationYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Movies");
        }
    }
}
