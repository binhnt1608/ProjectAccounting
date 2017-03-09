using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Inventory
    {

        public Inventory ()
        {
            InflowPurchaseInventories = new HashSet<InflowPurchaseInventory>();
            ReservationPurchaseOrderInventories = new HashSet<ReservationPurchaseOrderInventory>();
        }

        [Required]
        [Display(Name = "Inventory #")]
        public int InventoryID { get; set; }


        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        public string InventoryDescription { get; set; }

        [Display(Name = "Composition")]
        public int InventoryCompositionID { get; set; }

        [Display(Name = "Type")]
        public int InventoryTypeID { get; set; }

        [Display(Name = "Diameter")]
        public int InventoryDiameterID { get; set; }

        [Required]
        [Range(0, 10000)]
        [Display(Name = "List Price")]
        public string InventoryListPrice { get; set; }


        public InventoryComposition InventoryComposition { get; set; }

        public InventoryType InventoryType { get; set; }

        public InventoryDiameter InventoryDiameter { get; set; }

        //// Inventory  1-m Inflow P-I
        public virtual ICollection<InflowPurchaseInventory> InflowPurchaseInventories { get; set; }

        // Inventory 1-m Reservation PO-I
        public virtual ICollection<ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventories { get; set; }
    }
}
