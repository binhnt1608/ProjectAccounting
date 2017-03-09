using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InflowEmployeeWithholding
    {
        public int MaritalStatus { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Withholding Withholding { get; set; }
    }
}
