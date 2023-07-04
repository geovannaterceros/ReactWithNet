using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramsManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class renameOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPlates_Order_OrderId",
                table: "OrdersPlates");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrdersPlates",
                newName: "OrderNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersPlates_OrderId",
                table: "OrdersPlates",
                newName: "IX_OrdersPlates_OrderNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPlates_Order_OrderNavigationId",
                table: "OrdersPlates",
                column: "OrderNavigationId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPlates_Order_OrderNavigationId",
                table: "OrdersPlates");

            migrationBuilder.RenameColumn(
                name: "OrderNavigationId",
                table: "OrdersPlates",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersPlates_OrderNavigationId",
                table: "OrdersPlates",
                newName: "IX_OrdersPlates_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPlates_Order_OrderId",
                table: "OrdersPlates",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
