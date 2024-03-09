using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidzy.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "VideoGenres",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGenres", x => new { x.GenresId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_VideoGenres_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGenres_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGenres_VideosId",
                table: "VideoGenres",
                column: "VideosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGenres");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Videos");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "Genres",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
