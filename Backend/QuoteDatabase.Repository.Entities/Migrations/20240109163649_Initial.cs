using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteDatabase.Repository.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DisplayAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Book_Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Chapter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Page = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ActorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Song_Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Album = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Track = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
