using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InventoryType
    {
        public int InventoryTypeID { get; set; }

        [Display(Name = "Type Code")]
        public string InventoryTypeCode { get; set; }

        [Display(Name = "Type Description")]
        public string InventoryTypeDescription { get; set; }
    }
}
