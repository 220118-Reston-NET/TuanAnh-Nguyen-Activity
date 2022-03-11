using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeDL.Migrations
{
    public partial class AddPropToPokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Pokemons");
        }
    }
}
