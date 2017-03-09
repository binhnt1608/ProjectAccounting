using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InventoryType
    {
        [Display(Name = "Type #")]
        public int CompositionID { get; set; }

        [Display(Name = "Type Code")]
        public int InventoryTypeCode { get; set; }

        [Display(Name = "Type Description")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Description cannot be longer than 50 and at least 1 characters.")]
        public string InventoryTypeDescription { get; set; }
    }
}
