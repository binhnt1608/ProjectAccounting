using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Employee_1
    {
        public int EmployeeID { get; set; }

        // cashdisbursement 1-1
        public virtual CashDisbursement CashDisBursement { get; set; }
        //1-m labor acquisition
        public virtual ICollection<LaborAcquisition> LaborAcquisition { get; set; }
    }
}
