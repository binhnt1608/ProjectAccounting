using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class WorkSchedule
    {
        public WorkSchedule()
        {
            ReservationWSLTs = new HashSet<ReservationWSLT>();

            FulfillmentWSLAs = new HashSet<FulfillmentWSLA>();

        }

        [Key]
        [Display(Name = "Work Schedule #")]
        public int ScheduleID { get; set; }

        //1-m

        public virtual ICollection<FulfillmentWSLA> FulfillmentWSLAs { get; set; }

        public virtual ICollection<ReservationWSLT> ReservationWSLTs { get; set; }
    }
}
