using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;


namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<InflowPurchaseInventory>(entity =>
            {
                entity.HasKey(e => new { e.InventoryID, e.InventoryReceiptID });
                entity.HasOne(d => d.Inventory).WithMany(p => p.InflowPurchaseInventorys).HasForeignKey(d => d.InventoryID);
                entity.HasOne(d => d.Purchase).WithMany(p => p.InflowPurchaseInventorys).HasForeignKey(d => d.InventoryReceiptID);
                entity.ToTable("InflowPurchaseInventorys");
            }
            );

            builder.Entity<ReservationPurchaseOrderInventory>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseOrderID, e.InventoryID });
                entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.ReservationPurchaseOrderInventorys).HasForeignKey(d => d.PurchaseOrderID);
                entity.HasOne(d => d.Inventory).WithMany(p => p.ReservationPurchaseOrderInventorys).HasForeignKey(d => d.InventoryID);
                entity.ToTable("ReservationPurchaseOrderInventorys");
            }
            );

            builder.Entity<ReservationWSLT>(entity =>
            {
                entity.HasKey(e => new { e.LaborTypeID, e.ScheduleID });
                entity.HasOne(d => d.LaborType).WithMany(p => p.ReservationWSLTs).HasForeignKey(d => d.LaborTypeID);
                entity.HasOne(d => d.WorkSchedule).WithMany(p => p.ReservationWSLTs).HasForeignKey(d => d.ScheduleID);
                entity.ToTable("ReservationPurchaseOrderInventorys");
            }
            );

            builder.Entity<InflowLALT>(entity =>
            {
                entity.HasKey(e => new { e.TimeCardID, e.LaborTypeID });
                entity.HasOne(d => d.LaborAcquisition).WithMany(p => p.InflowLALTs).HasForeignKey(d => d.TimeCardID);
                entity.HasOne(d => d.LaborType).WithMany(p => p.InflowLALTs).HasForeignKey(d => d.LaborTypeID);
                entity.ToTable("ReservationPurchaseOrderInventorys");
            }
            );

            builder.Entity<FulfillmentWSLA>(entity =>
            {
                entity.HasKey(e => new { e.ScheduleID, e.TimeCardID });
                entity.HasOne(d => d.WorkSchedule).WithMany(p => p.FulfillmentWSLAs).HasForeignKey(d => d.ScheduleID);
                entity.HasOne(d => d.LaborAcquisition).WithMany(p => p.FulfillmentWSLAs).HasForeignKey(d => d.TimeCardID);
                entity.ToTable("ReservationPurchaseOrderInventorys");
            }
            );
        }

        public DbSet<CashAccount> CashAccount { get; set; }

        public DbSet<CashDisbursement> CashDisbursement { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeType> EmployeeType { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<InventoryComposition> InventoryComposition { get; set; }

        public DbSet<InventoryType> InventoryType { get; set; }

        public DbSet<InventoryDiameter> InventoryDiameter { get; set; }

        public DbSet<Purchase> Purchase { get; set; }

        public DbSet<InflowPurchaseInventory> InflowPurchaseInventory { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventory { get; set; }


    }
}
