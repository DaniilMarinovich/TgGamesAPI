using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomTgAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewUserGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageLvl",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HpLvl",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageLvl",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "HpLvl",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "UserGames");
        }
    }
}
