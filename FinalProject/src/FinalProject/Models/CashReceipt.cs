using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CashReceipt
    {
        [Display(Name = "RA #")]
        public int RemittanceAdviceID { get; set; }

        [Required]
        [Display(Name = "Cash Account #")]
        public int CashAccountID { get; set; }

        [Required]
        [Display(Name = "CR Type #")]
        public int CRTypeID { get; set; }

        [Required]
        [Display(Name = "Cash Receipt Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime CashReceiptDate { get; set; }

        [Required]
        [Display(Name = "Amount Received")]
        public int CasheReceiptAmount { get; set; }

        [Required]
        [Display(Name = "Payor Check #")]
        public int PayorCheckNum { get; set; }

        //Invoice
        [Required]
        [Display(Name = "Event #")]
        public int EventID { get; set; }

       
        //customer
        [Required]
        [Display(Name = "Payor #")]
        public int PayorID { get; set; }

        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        //m-1  sale cashaccount customer employee
        public virtual Sale Sale { get; set; }
        public virtual CashAccount CashAccount { get; set; }  
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual CashReceiptType CashReceiptType { get; set; }
        //1-1 stockSubscription
        public virtual StockSubscription StockSubscription { get; set; }

    }
}
