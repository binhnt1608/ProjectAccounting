using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Vendor
    {
        [Display(Name = "Vendor #")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Vendor's name cannot be longer than 50 and at least 1 characters.")]
        public string VendorName { get; set; }

        [Required]
        [Display(Name = "Address1")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address1 cannot be longer than 50 and at least 1 characters.")]
        public string VendorAddress1 { get; set; }

        [Display(Name = "Address1")]
        public string VendorAddress2 { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City cannot be longer than 50 and at least 1 characters.")]
        public string VendorCity { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State cannot be longer than 50 and at least 1 characters.")]
        public string VendorState { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string VendorZipCode { get; set; }

        [Required]
        [Display(Name = "Phone #")]
        public int VendorTelephone { get; set; }

        [Required]
        [Display(Name = "Primary Contact")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State cannot be longer than 50 and at least 1 characters.")]
        public string VendorPrimaryContact { get; set; }

        //cashdisbursement purchaseorder 1-m
        public virtual ICollection<CashDisbursement> CashDisbursement { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
