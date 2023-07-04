using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramsManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deleteIdOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPlates_Order_OrderId",
                table: "OrdersPlates");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrdersPlates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPlates_Order_OrderId",
                table: "OrdersPlates",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPlates_Order_OrderId",
                table: "OrdersPlates");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrdersPlates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPlates_Order_OrderId",
                table: "OrdersPlates",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
