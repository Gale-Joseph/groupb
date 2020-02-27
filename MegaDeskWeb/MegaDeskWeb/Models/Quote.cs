using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
    public class Quote
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Date")]
        public DateTime quoteDate { get; set; }
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Display(Name = "Width")]
        public int width { get; set; }
        [Display(Name = "Depth")]
        public int depth { get; set; }
        [Display(Name = "Drawers")]
        public int drawers { get; set; }
        [Display(Name = "Surface Materal")]
        public string surfaceMaterial { get; set; }
        [Display(Name = "Rush Delivery")]
        public int rushDelivery { get; set; }
        [Display(Name = "Total")]
        public double total { get; set; }
    }
}
