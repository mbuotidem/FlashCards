using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlashCards.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeckDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.DeckId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "DeckId", "CreationTimeStamp", "DeckDescription", "DeckName" },
                values: new object[] { 1, new DateTime(2021, 4, 7, 14, 8, 39, 402, DateTimeKind.Utc).AddTicks(558), "Seed Deck", "Seed Deck" });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "DeckId", "CreationTimeStamp", "DeckDescription", "DeckName" },
                values: new object[] { 2, new DateTime(2021, 4, 7, 14, 8, 39, 404, DateTimeKind.Utc).AddTicks(2010), "Seed Deck 2", "Seed Deck 2" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Correct", "CreationTimeStamp", "DeckId", "Definition", "Term" },
                values: new object[] { 1, false, new DateTime(2021, 4, 7, 14, 8, 39, 404, DateTimeKind.Utc).AddTicks(4040), 1, "A tool for learning", "Flashcard" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Correct", "CreationTimeStamp", "DeckId", "Definition", "Term" },
                values: new object[] { 2, false, new DateTime(2021, 4, 7, 14, 8, 39, 404, DateTimeKind.Utc).AddTicks(9553), 1, "A tool for losing", "Poker Card" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Correct", "CreationTimeStamp", "DeckId", "Definition", "Term" },
                values: new object[] { 3, false, new DateTime(2021, 4, 7, 14, 8, 39, 404, DateTimeKind.Utc).AddTicks(9695), 2, "A tool for living", "Insurance card" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId",
                table: "Cards",
                column: "DeckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
