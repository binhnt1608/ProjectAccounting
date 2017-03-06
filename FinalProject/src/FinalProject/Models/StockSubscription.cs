using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class StockSubscription
    {
        [Display(Name = "Issue #")]
        public int StockID { get; set; }

        [Required]
        [Display(Name = "StocKholder #")]
        public int FinancierID { get; set; }

        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "$ of Shares")]
        public int SharesIssued { get; set; }

        [Required]
        [Display(Name = "$ Per Share")]
        public int PricePerShare { get; set; }

        [Required]
        [Display(Name = "Issue Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime StockIssueDate { get; set; }

        //1-1 cashreceipt
        public virtual CashReceipt CashReceipt { get; set; }
        //m-1 StockholderCreditor Employee
        public virtual StockHolderCreditor StockHolderCreditor { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
