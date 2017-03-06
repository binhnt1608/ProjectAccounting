using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Sale
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime ShippingDate { get; set; }
        public int CustomerID { get; set; }
        public int SaleOrderID { get; set; }
        public int EmployeeID { get; set; }
        public int SaleAmount { get; set; }
        //  public virtual List<SaleOrder> SaleOrders { get; set; }
        public virtual List<Customer> Customer { get; set; }
        public virtual List<Employee> Employee { get; set; }

        // public SaleOrder SaleOrder { get; set; }
        //1-m cashreceipt
        public virtual ICollection<CashReceipt> CashReceipt { get; set; }

    }
}
