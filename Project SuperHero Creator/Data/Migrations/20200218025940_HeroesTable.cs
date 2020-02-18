using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_SuperHero_Creator.Data.Migrations
{
    public partial class HeroesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatchPhrase",
                table: "Heroes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatchPhrase",
                table: "Heroes");
        }
    }
}
