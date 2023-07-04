using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramsManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class renameOrderPlate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPlates_Order_OrderNavigationId",
                table: "OrdersPlates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPlates_Plate_PlateId",
                table: "OrdersPlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersPlates",
                table: "OrdersPlates");

            migrationBuilder.RenameTable(
                name: "OrdersPlates",
                newName: "OrderPlate");

            migrationBuilder.RenameColumn(
                name: "OrderNavigationId",
                table: "OrderPlate",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersPlates_PlateId",
                table: "OrderPlate",
                newName: "IX_OrderPlate_PlateId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersPlates_OrderNavigationId",
                table: "OrderPlate",
                newName: "IX_OrderPlate_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPlate",
                table: "OrderPlate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPlate_Order_OrderId",
                table: "OrderPlate",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPlate_Plate_PlateId",
                table: "OrderPlate",
                column: "PlateId",
                principalTable: "Plate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPlate_Order_OrderId",
                table: "OrderPlate");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPlate_Plate_PlateId",
                table: "OrderPlate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPlate",
                table: "OrderPlate");

            migrationBuilder.RenameTable(
                name: "OrderPlate",
                newName: "OrdersPlates");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrdersPlates",
                newName: "OrderNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPlate_PlateId",
                table: "OrdersPlates",
                newName: "IX_OrdersPlates_PlateId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPlate_OrderId",
                table: "OrdersPlates",
                newName: "IX_OrdersPlates_OrderNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersPlates",
                table: "OrdersPlates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPlates_Order_OrderNavigationId",
                table: "OrdersPlates",
                column: "OrderNavigationId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPlates_Plate_PlateId",
                table: "OrdersPlates",
                column: "PlateId",
                principalTable: "Plate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
