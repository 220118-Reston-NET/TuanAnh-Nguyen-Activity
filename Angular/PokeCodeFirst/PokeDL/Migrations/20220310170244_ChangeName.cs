using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeDL.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PokeId",
                table: "Pokemons",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pokemons",
                newName: "PokeId");
        }
    }
}
