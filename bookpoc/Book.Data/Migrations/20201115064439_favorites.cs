using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Data.Migrations
{
    public partial class favorites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "BookDetails");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookDetails",
                newName: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetails",
                table: "BookDetails",
                column: "BookId");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavId);
                    table.ForeignKey(
                        name: "FK_Favorites_BookDetails_BookId",
                        column: x => x.BookId,
                        principalTable: "BookDetails",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_BookId",
                table: "Favorites",
                column: "BookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetails",
                table: "BookDetails");

            migrationBuilder.RenameTable(
                name: "BookDetails",
                newName: "Book");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Book",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");
        }
    }
}
