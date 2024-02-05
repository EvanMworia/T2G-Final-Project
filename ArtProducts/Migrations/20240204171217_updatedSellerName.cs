using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtProducts.Migrations
{
    /// <inheritdoc />
    public partial class updatedSellerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ArtPieces",
                newName: "SellerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellerName",
                table: "ArtPieces",
                newName: "UserName");
        }
    }
}
