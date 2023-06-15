using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCharacterAPI.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "PictureURL" },
                values: new object[,]
                {
                    { 1, "Iron Man", "Robert Downey Jr.", "Male", null },
                    { 2, "Thor", "Chris Hemsworth", "Male", null },
                    { 3, "Captain America", "Chris Evans", "Male", null },
                    { 4, "Spider Man", "Tom Holland", "Male", null }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "FranchiseId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Iron Man Series" },
                    { 2, null, "Spider Man Series" },
                    { 3, null, "Thor Series" },
                    { 4, null, "Captain America Series" },
                    { 5, null, "Marvel Universe" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "PictureURL", "ReleaseYear", "Title", "TrailerURL" },
                values: new object[,]
                {
                    { 1, "Jon Favreau", 1, "Comic Book,Superhero", null, 2008, "Iron Man", null },
                    { 4, "Jon Watts", 2, "Comic Book, Superhero", null, 2017, "SpiderMan Homecoming", null },
                    { 2, "Kenneth Branagh", 3, "Comic Book,Superhero", null, 2011, "Thor", null },
                    { 3, "Joss Whedon", 5, "Comic Book, Superhero", null, 2012, "The Avengers", null },
                    { 5, "Anthony and Joe Russo", 5, "Comic Book, Superhero", null, 2018, "Avengers: Infinity War", null }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 4, 4 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersCharacterId", "MoviesMovieId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 5);
        }
    }
}
