using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Exemptions
    {
        [Required]
        [Display(Name = "Exemption Number")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Firstname cannot be longer than 50 and at least 1 characters.")]
        public int ExemptionNum { get; set; }
    }
}
