using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CashDisbursement
    {
        [Key]
        [Display(Name = "Check Number #")]
        public int CheckNumber { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime CashDisbursementDate { get; set; }

        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Display(Name = "Vendor #")]
        public int VendorID { get; set; }

        [Display(Name = "Cash Account #")]
        public int CashAccountID { get; set; }

        //purchase cashaccount employee vendor m-1
        public virtual Purchase Purchase { get; set; }
        public virtual CashAccount CashAccount { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
