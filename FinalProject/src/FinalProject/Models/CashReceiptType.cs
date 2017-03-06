using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CashReceiptType
    {
        [Display(Name = "CR Type #")]
        public int CRTypeID { get; set; }

        [Required]
        [Display(Name = "Related Event")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Related Event cannot be longer than 50 and at least 1 characters.")]
        public string EventTypeName { get; set; }

        [Required]
        [Display(Name = "Payee Type")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "PayeeType cannot be longer than 50 and at least 1 characters.")]
        public string PayeeTypeName { get; set; }

        //1-m Cashreceipt
        public virtual ICollection<CashReceipt> CashReceipt { get; set; }
    }
}
