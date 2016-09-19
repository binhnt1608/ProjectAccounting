using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InventoryDiameter
    {
        public int InventoryDiameterID { get; set; }

        [Display(Name = "Diameter Code")]
        public string InventoryDiameterCode { get; set; }

        [Display(Name = "Diameter Description")]
        public string InventoryDiameterDescription { get; set; }
    }
}
