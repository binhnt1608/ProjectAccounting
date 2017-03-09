using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class LaborType
    {
        public LaborType()
        {
            ReservationWSLTs = new HashSet<ReservationWSLT>();
            InflowLALTs = new HashSet<InflowLALT>();
        }

        [Key]
        [Display(Name = "Labor Type #")]
        public int LaborTypeID { get; set; }

        //1-m InflowLALT ReservantionWSLT
        public virtual ICollection<InflowLALT> InflowLALTs { get; set; }
        public virtual ICollection<ReservationWSLT> ReservationWSLTs { get; set; }
    }
}
