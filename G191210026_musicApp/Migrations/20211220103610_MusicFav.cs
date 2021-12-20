using Microsoft.EntityFrameworkCore.Migrations;

namespace G191210026_musicApp.Migrations
{
    public partial class MusicFav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavCount",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavCount",
                table: "Musics");
        }
    }
}
