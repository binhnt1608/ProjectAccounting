using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class AddInventory_PurchaseOrder_ReservationPurchaseOrderInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationPurchaseOrderInventorys",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false),
                    InventoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPurchaseOrderInventorys", x => new { x.PurchaseOrderID, x.InventoryID });
                    table.ForeignKey(
                        name: "FK_ReservationPurchaseOrderInventorys_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationPurchaseOrderInventorys_PurchaseOrder_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPurchaseOrderInventorys_InventoryID",
                table: "ReservationPurchaseOrderInventorys",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPurchaseOrderInventorys_PurchaseOrderID",
                table: "ReservationPurchaseOrderInventorys",
                column: "PurchaseOrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationPurchaseOrderInventorys");
        }
    }
}
