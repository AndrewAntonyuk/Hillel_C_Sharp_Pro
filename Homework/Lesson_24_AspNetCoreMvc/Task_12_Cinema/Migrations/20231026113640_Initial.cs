using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_12_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: true),
                    ShortBio = table.Column<string>(type: "NVARCHAR(1500)", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                    table.CheckConstraint("CK_Director_FirstName", "LEN(TRIM([FirstName])) > 0");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.CheckConstraint("CK_Genre_Name", "LEN(TRIM([Name])) > 0");
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    GenreId = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    DirectorId = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "NVARCHAR(1500)", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.CheckConstraint("CK_Film_Name", "LEN(TRIM([Name])) > 0");
                    table.ForeignKey(
                        name: "FK_Film_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Film_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDateTime = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2023, 10, 26, 11, 36, 40, 347, DateTimeKind.Utc).AddTicks(4781)),
                    FilmId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "ShortBio" },
                values: new object[,]
                {
                    { 1, "Martin", "Scorsese", null, "We`re talking about the guy who made Taxi Driver here! No one has more classics than Scorsese, including directors like James Cameron and David Fincher. His resume includes Raging Bull, Goodfellas, Mean Streets, Cape Fear, Shutter Island, and The Last Waltz. Famously, it took Scorsese a while to win an Oscar, but they eventually gave him one for The Departed." },
                    { 2, "Guillermo", "del Toro", null, "For the longest time, Guillermo del Toro was one of those under-the-radar directors. Then he made Pan`s Labyrinth, Hellboy, and The Shape of Water. Now you can`t watch a football game without seeing an ad for Nightmare Alley. His success is further proof that good work+hard work will eventually= acclaim." },
                    { 3, "Christopher", "Nolan", null, "Like Fincher, Nolan is a track-record director. He`s 11 for 11 on feature films. Sure, he`s only made a couple of great films (Dunkirk, The Dark Knight), but he`s never made a movie that isn`t worth watching." },
                    { 4, "James", "Cameron", null, "Is anyone talking about Apichatapong? Not really. Cameron, on the other hand? He`s a living legend. He`s discussed more than any other director on here. Whether we`re talking about Terminator 2 or The Titanic, Cameron has managed to stay relevant for as long as I`ve been alive. His Avatar films will keep it that way for years to come." },
                    { 5, "Steven", "Spielberg", null, "Pick an age, any age: Spielberg has the power to make you feel like a kid again. It doesn`t matter if you`re 8 or 88, ET,  Indiana Jones, and Jurassic Park will have you grinning from ear-to-ear. Even at 75, the man is still finding ways to make us smile. " }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Associated with particular types of spectacle (e.g., explosions, chases, combat).", "Action" },
                    { 2, "Implies a narrative that is defined by a journey (often including some form of pursuit) and is usually located within a fantasy or exoticized setting.", "Adventure" },
                    { 3, "Defined by events that are primarily intended to make the audience laugh.", "Comedy" },
                    { 4, "Focused on emotions and defined by conflict, often looking to reality rather than sensationalism.", "Drama" },
                    { 5, "Films defined by situations that transcend natural laws and/or by settings inside a fictional universe, with narratives that are often inspired by or involve human myths.", "Fantasy" },
                    { 6, "Films that seek to elicit fear or disgust in the audience for entertainment purposes.", "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "Id", "Description", "DirectorId", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Its plot centers on a series of Oklahoma murders in the Osage Nation during the 1920s, committed after oil was discovered on tribal land.", 1, 4, "Killers of the Flower Moon" },
                    { 2, "In 1954, U.S. Marshal Edward \"Teddy\" Daniels and his new partner Chuck Aule travel to Ashecliffe Hospital for the criminally insane on Shutter Island, Boston Harbor to investigate the disappearance of Rachel Solando, a patient of the hospital who had previously drowned her three children.", 1, 6, "Shutter Island" },
                    { 3, "The film draws inspiration from the debut comic Hellboy: Seed of Destruction. In the film, a charismatic demon-turned-investigator named \"Hellboy\" works with the secretive Bureau of Paranormal Research and Defense to suppress paranormal threats, but a resurrected sorcerer seeks to make Hellboy fulfill his destiny by triggering the apocalypse.", 2, 2, "Hellboy" },
                    { 4, "In 2067, humanity is facing extinction following a global famine caused by ecocide. As a result, ex-NASA pilot, Joseph Cooper, is forced to work as a farmer, with his son Tom, daughter Murph and father-in-law Donald.", 3, 5, "Interstellar" },
                    { 5, "Two men arrive separately in 1984 Los Angeles, having time traveled from 2029. One is a cybernetic assassin known as a Terminator, programmed to hunt and kill a woman named Sarah Connor. The other is a human soldier named Kyle Reese, intent on stopping it. They both steal guns and clothing.", 4, 1, "The Terminator" },
                    { 6, "In 1969, FBI agent Carl Hanratty arrives in Marseille, France, to pick up a prisoner named Frank Abagnale Jr. who became ill due to the prison`s conditions.", 5, 2, "Catch Me If You Can" }
                });

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "Id", "EventDateTime", "FilmId" },
                values: new object[] { 1, new DateTime(2023, 11, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Director_FirstName_MiddleName_LastName",
                table: "Director",
                columns: new[] { "FirstName", "MiddleName", "LastName" },
                unique: true,
                filter: "[MiddleName] IS NOT NULL AND [LastName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Film_DirectorId",
                table: "Film",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_GenreId",
                table: "Film",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Name",
                table: "Film",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_FilmId_EventDateTime",
                table: "Session",
                columns: new[] { "FilmId", "EventDateTime" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
