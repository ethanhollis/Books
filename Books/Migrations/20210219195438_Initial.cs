using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookTitle = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AuthorFirst = table.Column<string>(nullable: true),
                    AuthorLast = table.Column<string>(nullable: true),
                    AuthorMiddle = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
