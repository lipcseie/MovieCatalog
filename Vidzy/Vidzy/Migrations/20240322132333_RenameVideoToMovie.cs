using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidzy.Migrations
{
    /// <inheritdoc />
    public partial class RenameVideoToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoTags_Videos_VideosId",
                table: "VideoTags");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoTags",
                table: "VideoTags");

            migrationBuilder.DropIndex(
                name: "IX_VideoTags_VideosId",
                table: "VideoTags");

            migrationBuilder.RenameColumn(
                name: "VideosId",
                table: "VideoTags",
                newName: "MoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoTags",
                table: "VideoTags",
                columns: new[] { "MoviesId", "TagsId" });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<byte>(type: "tinyint", nullable: false),
                    Classification = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoTags_TagsId",
                table: "VideoTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTags_Movies_MoviesId",
                table: "VideoTags",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoTags_Movies_MoviesId",
                table: "VideoTags");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoTags",
                table: "VideoTags");

            migrationBuilder.DropIndex(
                name: "IX_VideoTags_TagsId",
                table: "VideoTags");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "VideoTags",
                newName: "VideosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoTags",
                table: "VideoTags",
                columns: new[] { "TagsId", "VideosId" });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<byte>(type: "tinyint", nullable: false),
                    Classification = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoTags_VideosId",
                table: "VideoTags",
                column: "VideosId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GenreId",
                table: "Videos",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTags_Videos_VideosId",
                table: "VideoTags",
                column: "VideosId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
