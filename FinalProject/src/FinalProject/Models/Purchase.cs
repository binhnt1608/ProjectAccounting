using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Purchase
    {
        public Purchase ()
        {
            InflowPurchaseInventorys = new HashSet<InflowPurchaseInventory>();
        }

        [Key]
        [Display(Name = "Purchase #")]
        public int InventoryReceiptID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        public DateTime ReceivingReportDate { get; set; }


        [Required]
        [Display(Name = "Vendor Invoice ID")]
        public int ReceivingReportVendorInvoiceID { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public string VendorID { get; set; }

        //m-1
        public virtual Employee Employee { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        //1-m
        public virtual ICollection<CashDisbursement> CashDisbursement { get; set; }


        public virtual ICollection<InflowPurchaseInventory> InflowPurchaseInventorys { get; set; }
    }

}
