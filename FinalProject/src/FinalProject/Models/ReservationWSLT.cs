using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ReservationWSLT
    {

        public int ScheduleID { get; set; }

        public int LaborTypeID { get; set; }

        public virtual WorkSchedule WorkSchedule { get; set; }

        public virtual LaborType LaborType { get; set; }
    }
}
