using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class StockHolderCreditor
    {
        [Display(Name = "Financier #")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Vendor's name cannot be longer than 50 and at least 1 characters.")]
        public string FinancierName { get; set; }

        [Required]
        [Display(Name = "Address1")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address1 cannot be longer than 50 and at least 1 characters.")]
        public string FinancierAddress1 { get; set; }

        [Display(Name = "Address1")]
        public string FinancierAddress2 { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City cannot be longer than 50 and at least 1 characters.")]
        public string FinancierCity { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State cannot be longer than 50 and at least 1 characters.")]
        public string FinancierState { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string FinancierZipCode { get; set; }

        [Required]
        [Display(Name = "Phone #")]
        public int FinancierTelephone { get; set; }

        [Required]
        [Display(Name = "Primary Contact")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State cannot be longer than 50 and at least 1 characters.")]
        public string FinancierPrimaryContact { get; set; }

        //1-m LoanAgreemnet StockSubscription FulfillmentSSCD
        public virtual ICollection<LoanAgreement> LoanAgreemnet { get; set; }
        public virtual ICollection<StockSubscription> StockSubscription { get; set; }
        public virtual ICollection<FulfillmentSSCD> FulfillmentSSCD { get; set; }
      
    }
}
