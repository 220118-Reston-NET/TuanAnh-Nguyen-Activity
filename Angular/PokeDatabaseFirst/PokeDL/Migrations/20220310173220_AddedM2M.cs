using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeDL.Migrations
{
    public partial class AddedM2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Pokemons_PokemonPokeId",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_PokemonPokeId",
                table: "Abilities");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonPokeId",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AbilityPokemon",
                columns: table => new
                {
                    AbilitiesAbId = table.Column<int>(type: "int", nullable: false),
                    PokemonsPokeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityPokemon", x => new { x.AbilitiesAbId, x.PokemonsPokeId });
                    table.ForeignKey(
                        name: "FK_AbilityPokemon_Abilities_AbilitiesAbId",
                        column: x => x.AbilitiesAbId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityPokemon_Pokemons_PokemonsPokeId",
                        column: x => x.PokemonsPokeId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityPokemon_PokemonsPokeId",
                table: "AbilityPokemon",
                column: "PokemonsPokeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityPokemon");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonPokeId",
                table: "Abilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_PokemonPokeId",
                table: "Abilities",
                column: "PokemonPokeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Pokemons_PokemonPokeId",
                table: "Abilities",
                column: "PokemonPokeId",
                principalTable: "Pokemons",
                principalColumn: "Id");
        }
    }
}
