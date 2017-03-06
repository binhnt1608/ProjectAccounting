using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Customer
    {
        [Display(Name = "ID")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        public string CustomerAddress1 { get; set; }

        [Display(Name = "Address 2")]
        public string CustomerAddress2 { get; set; }

        [Required]
        [Display(Name = "City")]
        public string CustomerCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string CustomerState { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public string CustomerZipcode { get; set; }

        [Required]
        public string CustomerTelephone { get; set; }

        [Range(0, 50000)]
        [Display(Name = "Credit Limit")]
        public decimal CustomerCreditLimit { get; set; }

        [Display(Name = "Primary Contact")]
        public string CustomerPrimaryContact { get; set; }

        //1-m cashreceipt
        public virtual ICollection<CashReceipt> CashReceipt { get; set; }
    }
}
