using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class SaleOrder
    {
        [Key]
        public int SaleOrderID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime SaleOrderDate { get; set; }

        public int CustomerID { get; set; }

        public string CustomerPO { get; set; }

        public float SaleOrderAmount { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<Customer> Customers { get; set; }

    }
}
