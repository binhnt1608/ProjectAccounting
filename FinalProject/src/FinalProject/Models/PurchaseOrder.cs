using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            ReservationPurchaseOrderInventories = new HashSet<ReservationPurchaseOrderInventory>();
        }
        [Display(Name = "Purchase Order #")]
        public int PurchaseOrderID { get; set; }

        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Display(Name = "Vendor #")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseOrderDate { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime ExpectedDeliveryDate { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public string PurchaseOrderAmount { get; set; }

        //fk
        //Employee vendor m-1
        public virtual Employee Employee { get; set; }
        public virtual Vendor Vendor { get; set; }

        //Purchase 1-m
        public virtual ICollection<Purchase> Purchase { get; set; }

        // 1-m Reservation PO-I
        public virtual ICollection<ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventories { get; set; }
    }
}
