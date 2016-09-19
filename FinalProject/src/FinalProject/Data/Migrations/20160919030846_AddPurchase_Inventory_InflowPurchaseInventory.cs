using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class AddPurchase_Inventory_InflowPurchaseInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InflowPurchaseInventorys",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false),
                    InventoryReceiptID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InflowPurchaseInventorys", x => new { x.InventoryID, x.InventoryReceiptID });
                    table.ForeignKey(
                        name: "FK_InflowPurchaseInventorys_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InflowPurchaseInventorys_Purchase_InventoryReceiptID",
                        column: x => x.InventoryReceiptID,
                        principalTable: "Purchase",
                        principalColumn: "InventoryReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InflowPurchaseInventorys_InventoryID",
                table: "InflowPurchaseInventorys",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InflowPurchaseInventorys_InventoryReceiptID",
                table: "InflowPurchaseInventorys",
                column: "InventoryReceiptID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InflowPurchaseInventorys");
        }
    }
}
