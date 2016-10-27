using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InflowLALT
    {
        public int TimeCardID { get; set; }

        public int LaborTypeID { get; set; }

        public virtual LaborType LaborType { get; set; }

        public virtual LaborAcquisition LaborAcquisition { get; set; }
    }
}
