using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InventoryComposition
    {
        [Display(Name = "Composition #")]
        public int CompositionID { get; set; }

        [Required]
        [Display(Name = "Composition Code")]
        public string InventoryCompositionCode { get; set; }

        [Display(Name = "Description")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Description cannot be longer than 50 and at least 1 characters.")]
        public string InventoryCompositionDescription { get; set; }
    }
}
