using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashAccount",
                columns: table => new
                {
                    CashAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountDescription = table.Column<string>(maxLength: 255, nullable: true),
                    BankAccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    BankName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAccount", x => x.CashAccountID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerAddress1 = table.Column<string>(nullable: false),
                    CustomerAddress2 = table.Column<string>(nullable: true),
                    CustomerCity = table.Column<string>(nullable: false),
                    CustomerCreditLimit = table.Column<decimal>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerPrimaryContact = table.Column<string>(nullable: true),
                    CustomerState = table.Column<string>(nullable: false),
                    CustomerTelephone = table.Column<string>(nullable: false),
                    CustomerZipcode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryComposition",
                columns: table => new
                {
                    InventoryCompositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryCompositionCode = table.Column<string>(nullable: true),
                    InventoryCompositionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryComposition", x => x.InventoryCompositionID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDiameter",
                columns: table => new
                {
                    InventoryDiameterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryDiameterCode = table.Column<string>(nullable: true),
                    InventoryDiameterDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDiameter", x => x.InventoryDiameterID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryType",
                columns: table => new
                {
                    InventoryTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryTypeCode = table.Column<string>(nullable: true),
                    InventoryTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryType", x => x.InventoryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    VendorAddress2 = table.Column<string>(nullable: true),
                    VendorCity = table.Column<string>(maxLength: 50, nullable: false),
                    VendorName = table.Column<string>(maxLength: 50, nullable: false),
                    VendorPrimaryContact = table.Column<string>(maxLength: 50, nullable: false),
                    VendorState = table.Column<string>(maxLength: 50, nullable: false),
                    VendorTelephone = table.Column<int>(nullable: false),
                    VendorZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeID",
                        column: x => x.EmployeeTypeID,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryCompositionID = table.Column<int>(nullable: false),
                    InventoryDescription = table.Column<string>(maxLength: 255, nullable: true),
                    InventoryDiameterID = table.Column<int>(nullable: false),
                    InventoryListPrice = table.Column<string>(nullable: false),
                    InventoryTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryComposition_InventoryCompositionID",
                        column: x => x.InventoryCompositionID,
                        principalTable: "InventoryComposition",
                        principalColumn: "InventoryCompositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryDiameter_InventoryDiameterID",
                        column: x => x.InventoryDiameterID,
                        principalTable: "InventoryDiameter",
                        principalColumn: "InventoryDiameterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryType_InventoryTypeID",
                        column: x => x.InventoryTypeID,
                        principalTable: "InventoryType",
                        principalColumn: "InventoryTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(nullable: false),
                    PurchaseOrderAmount = table.Column<string>(nullable: false),
                    PurchaseOrderDate = table.Column<DateTime>(nullable: false),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    InventoryReceiptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    PurchaseOrderID = table.Column<int>(nullable: true),
                    ReceivingReportDate = table.Column<DateTime>(nullable: false),
                    ReceivingReportVendorInvoiceID = table.Column<int>(nullable: false),
                    VendorID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.InventoryReceiptID);
                    table.ForeignKey(
                        name: "FK_Purchase_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_PurchaseOrder_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashDisbursement",
                columns: table => new
                {
                    CheckNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CashAccountID = table.Column<int>(nullable: false),
                    CashDisbursementDate = table.Column<DateTime>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    PurchaseInventoryReceiptID = table.Column<int>(nullable: true),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDisbursement", x => x.CheckNumber);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_CashAccount_CashAccountID",
                        column: x => x.CashAccountID,
                        principalTable: "CashAccount",
                        principalColumn: "CashAccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_Purchase_PurchaseInventoryReceiptID",
                        column: x => x.PurchaseInventoryReceiptID,
                        principalTable: "Purchase",
                        principalColumn: "InventoryReceiptID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_CashAccountID",
                table: "CashDisbursement",
                column: "CashAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_EmployeeID",
                table: "CashDisbursement",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_PurchaseInventoryReceiptID",
                table: "CashDisbursement",
                column: "PurchaseInventoryReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_CashDisbursement_VendorID",
                table: "CashDisbursement",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeID",
                table: "Employee",
                column: "EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryCompositionID",
                table: "Inventory",
                column: "InventoryCompositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryDiameterID",
                table: "Inventory",
                column: "InventoryDiameterID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryTypeID",
                table: "Inventory",
                column: "InventoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_EmployeeID",
                table: "Purchase",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PurchaseOrderID",
                table: "Purchase",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_EmployeeID",
                table: "PurchaseOrder",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_VendorID",
                table: "PurchaseOrder",
                column: "VendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashDisbursement");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "CashAccount");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "InventoryComposition");

            migrationBuilder.DropTable(
                name: "InventoryDiameter");

            migrationBuilder.DropTable(
                name: "InventoryType");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "EmployeeType");
        }
    }
}
