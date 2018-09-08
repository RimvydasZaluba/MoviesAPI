using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    RunningTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirtName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserId, x.MovieId });
                    table.UniqueConstraint("AK_Ratings_MovieId_UserId", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Horror" },
                    { 3, "Comedy" },
                    { 4, "Superhero" },
                    { 5, "Thriller" },
                    { 6, "Sci-fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseDate", "RunningTime", "Title" },
                values: new object[,]
                {
                    { 8, new DateTime(2002, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, "Equilibrium " },
                    { 7, new DateTime(2009, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, "Moon" },
                    { 6, new DateTime(2012, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, "Seven Psychopaths" },
                    { 5, new DateTime(2005, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, "The Hitchhiker's Guide to the Galaxy" },
                    { 3, new DateTime(1994, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, "The Crow" },
                    { 2, new DateTime(2003, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, "Freddy vs Jason" },
                    { 1, new DateTime(2016, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, "Deadpool" },
                    { 4, new DateTime(1999, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, "Dogma" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirtName", "LastName" },
                values: new object[,]
                {
                    { 2, "Jane", "Doe" },
                    { 1, "John", "Smith" },
                    { 3, "Tester", "McTesteson" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 8 },
                    { 5, 8 },
                    { 1, 8 },
                    { 5, 6 },
                    { 3, 6 },
                    { 6, 5 },
                    { 3, 5 },
                    { 3, 4 },
                    { 6, 7 },
                    { 4, 3 },
                    { 1, 3 },
                    { 3, 2 },
                    { 2, 2 },
                    { 6, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "UserId", "MovieId", "Stars" },
                values: new object[,]
                {
                    { 2, 6, 2 },
                    { 2, 7, 3 },
                    { 2, 8, 1 },
                    { 3, 1, 5 },
                    { 3, 5, 3 },
                    { 3, 3, 5 },
                    { 3, 4, 3 },
                    { 3, 6, 2 },
                    { 2, 5, 4 },
                    { 3, 2, 4 },
                    { 2, 4, 5 },
                    { 1, 3, 4 },
                    { 2, 2, 5 },
                    { 2, 1, 4 },
                    { 1, 8, 4 },
                    { 1, 7, 5 },
                    { 1, 6, 3 },
                    { 1, 5, 1 },
                    { 1, 4, 2 },
                    { 3, 7, 1 },
                    { 1, 2, 3 },
                    { 1, 1, 5 },
                    { 2, 3, 4 },
                    { 3, 8, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
