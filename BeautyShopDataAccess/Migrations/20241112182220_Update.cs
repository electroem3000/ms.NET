using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyShopDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_ExternalId",
                table: "User",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ExternalId",
                table: "ProductEntity",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ExternalId",
                table: "OrderProducts",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_ExternalId",
                table: "OrderEntity",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardEntity_ExternalId",
                table: "CardEntity",
                column: "ExternalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_ExternalId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_ProductEntity_ExternalId",
                table: "ProductEntity");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ExternalId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntity_ExternalId",
                table: "OrderEntity");

            migrationBuilder.DropIndex(
                name: "IX_CardEntity_ExternalId",
                table: "CardEntity");
        }
    }
}
