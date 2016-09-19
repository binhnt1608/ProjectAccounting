using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FinalProject.Data;

namespace FinalProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160919030846_AddPurchase_Inventory_InflowPurchaseInventory")]
    partial class AddPurchase_Inventory_InflowPurchaseInventory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FinalProject.Models.CashAccount", b =>
                {
                    b.Property<int>("CashAccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountDescription")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("CashAccountID");

                    b.ToTable("CashAccount");
                });

            modelBuilder.Entity("FinalProject.Models.CashDisbursement", b =>
                {
                    b.Property<int>("CheckNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CashAccountID");

                    b.Property<DateTime>("CashDisbursementDate");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("PurchaseInventoryReceiptID");

                    b.Property<int>("VendorID");

                    b.HasKey("CheckNumber");

                    b.HasIndex("CashAccountID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("PurchaseInventoryReceiptID");

                    b.HasIndex("VendorID");

                    b.ToTable("CashDisbursement");
                });

            modelBuilder.Entity("FinalProject.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerAddress1")
                        .IsRequired();

                    b.Property<string>("CustomerAddress2");

                    b.Property<string>("CustomerCity")
                        .IsRequired();

                    b.Property<decimal>("CustomerCreditLimit");

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<string>("CustomerPrimaryContact");

                    b.Property<string>("CustomerState")
                        .IsRequired();

                    b.Property<string>("CustomerTelephone")
                        .IsRequired();

                    b.Property<string>("CustomerZipcode")
                        .IsRequired();

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeFirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("EmployeeTypeID");

                    b.HasKey("EmployeeID");

                    b.HasIndex("EmployeeTypeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("FinalProject.Models.EmployeeType", b =>
                {
                    b.Property<int>("EmployeeTypeID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("EmployeeTypeID");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("FinalProject.Models.InflowPurchaseInventory", b =>
                {
                    b.Property<int>("InventoryID");

                    b.Property<int>("InventoryReceiptID");

                    b.HasKey("InventoryID", "InventoryReceiptID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("InventoryReceiptID");

                    b.ToTable("InflowPurchaseInventorys");
                });

            modelBuilder.Entity("FinalProject.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryCompositionID");

                    b.Property<string>("InventoryDescription")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("InventoryDiameterID");

                    b.Property<string>("InventoryListPrice")
                        .IsRequired();

                    b.Property<int>("InventoryTypeID");

                    b.HasKey("InventoryID");

                    b.HasIndex("InventoryCompositionID");

                    b.HasIndex("InventoryDiameterID");

                    b.HasIndex("InventoryTypeID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("FinalProject.Models.InventoryComposition", b =>
                {
                    b.Property<int>("InventoryCompositionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryCompositionCode");

                    b.Property<string>("InventoryCompositionDescription");

                    b.HasKey("InventoryCompositionID");

                    b.ToTable("InventoryComposition");
                });

            modelBuilder.Entity("FinalProject.Models.InventoryDiameter", b =>
                {
                    b.Property<int>("InventoryDiameterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryDiameterCode");

                    b.Property<string>("InventoryDiameterDescription");

                    b.HasKey("InventoryDiameterID");

                    b.ToTable("InventoryDiameter");
                });

            modelBuilder.Entity("FinalProject.Models.InventoryType", b =>
                {
                    b.Property<int>("InventoryTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryTypeCode");

                    b.Property<string>("InventoryTypeDescription");

                    b.HasKey("InventoryTypeID");

                    b.ToTable("InventoryType");
                });

            modelBuilder.Entity("FinalProject.Models.Purchase", b =>
                {
                    b.Property<int>("InventoryReceiptID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("PurchaseOrderID");

                    b.Property<DateTime>("ReceivingReportDate");

                    b.Property<int>("ReceivingReportVendorInvoiceID");

                    b.Property<string>("VendorID")
                        .IsRequired();

                    b.HasKey("InventoryReceiptID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("PurchaseOrderID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("FinalProject.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<DateTime>("ExpectedDeliveryDate");

                    b.Property<string>("PurchaseOrderAmount")
                        .IsRequired();

                    b.Property<DateTime>("PurchaseOrderDate");

                    b.Property<int>("VendorID");

                    b.HasKey("PurchaseOrderID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("VendorID");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("FinalProject.Models.Vendor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VendorAddress1")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("VendorAddress2");

                    b.Property<string>("VendorCity")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("VendorPrimaryContact")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("VendorState")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("VendorTelephone");

                    b.Property<string>("VendorZipCode")
                        .IsRequired();

                    b.HasKey("VendorID");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FinalProject.Models.CashDisbursement", b =>
                {
                    b.HasOne("FinalProject.Models.CashAccount", "CashAccount")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("CashAccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Purchase", "Purchase")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("PurchaseInventoryReceiptID");

                    b.HasOne("FinalProject.Models.Vendor", "Vendor")
                        .WithMany("CashDisbursement")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.HasOne("FinalProject.Models.EmployeeType", "EmployeeType")
                        .WithMany("Employee")
                        .HasForeignKey("EmployeeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProject.Models.InflowPurchaseInventory", b =>
                {
                    b.HasOne("FinalProject.Models.Inventory", "Inventory")
                        .WithMany("InflowPurchaseInventorys")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Purchase", "Purchase")
                        .WithMany("InflowPurchaseInventorys")
                        .HasForeignKey("InventoryReceiptID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProject.Models.Inventory", b =>
                {
                    b.HasOne("FinalProject.Models.InventoryComposition", "InventoryComposition")
                        .WithMany()
                        .HasForeignKey("InventoryCompositionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.InventoryDiameter", "InventoryDiameter")
                        .WithMany()
                        .HasForeignKey("InventoryDiameterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.InventoryType", "InventoryType")
                        .WithMany()
                        .HasForeignKey("InventoryTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProject.Models.Purchase", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany("Purchase")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("Purchase")
                        .HasForeignKey("PurchaseOrderID");
                });

            modelBuilder.Entity("FinalProject.Models.PurchaseOrder", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany("PurchaseOrder")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Vendor", "Vendor")
                        .WithMany("PurchaseOrder")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FinalProject.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinalProject.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
