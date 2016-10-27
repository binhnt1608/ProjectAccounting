using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class FulfillmentWSLA
    {
        public int ScheduleID { get; set; }

        public int TimeCardID { get; set; }

        public virtual LaborAcquisition LaborAcquisition { get; set; }

        public virtual WorkSchedule WorkSchedule { get; set; }
        
    }
}
