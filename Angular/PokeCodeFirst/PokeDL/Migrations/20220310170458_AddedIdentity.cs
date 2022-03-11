using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeDL.Migrations
{
    public partial class AddedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AbId",
                table: "Abilities",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Abilities",
                newName: "AbId");
        }
    }
}
