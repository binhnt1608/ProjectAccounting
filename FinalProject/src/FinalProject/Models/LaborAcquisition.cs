using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class LaborAcquisition
    {
        public int TimeCardID { get; set; }

        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Supervisor #")]
        public int EmployeeSupervisorID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime LAPayPeriodEnded { get; set; }

        [Required]
        [Display(Name = "LARegular Time")]
        [Range(0,184,ErrorMessage = "Please enter a number between 0 and 184.")]
        public int LARegularTime { get; set; }

        [Required]
        [Display(Name = "LAOver Time")]
        [Range(0,200, ErrorMessage ="Please enter a number between 0 and 200")]
        public int LAOvertime { get; set; }
    }
}
