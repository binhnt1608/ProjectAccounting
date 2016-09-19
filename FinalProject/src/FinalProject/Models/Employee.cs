using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Employee
    {
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Lastname cannot be longer than 50 and at least 1 characters.")]
        public string EmployeeLastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Firstname cannot be longer than 50 and at least 1 characters.")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Type")]
        public int EmployeeTypeID { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
