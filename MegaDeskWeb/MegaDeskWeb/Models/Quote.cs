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
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string firstname { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string lastname { get; set; }
        [Display(Name = "Width")]
        [Range(24, 96)]
        public int width { get; set; }
       
        [Display(Name = "Depth")]
        [Range(12, 48)]
        public int depth { get; set; }
       
        [Display(Name = "Drawers")]
        [Range(0, 7)]
        public int drawers { get; set; }
       
        [Display(Name = "Surface Materal")]
        public string surfaceMaterial { get; set; }
        [Display(Name = "Rush Delivery")]
        public int rushDelivery { get; set; }
        [Display(Name = "Total")]
        public double total { get; set; }
        [Display(Name = "Width2")]
        public int width2 { get; set; }
    }
}
