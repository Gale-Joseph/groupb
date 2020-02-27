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
        
        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime quoteDate { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string lastname { get; set; }

        [Display(Name = "Width")]
        [Range(1, 10000)]
        public double width { get; set; }

        [Display(Name = "Depth")]
        [Range(1, 10000)]
        public double depth { get; set; }
        
        [Display(Name = "Drawers")]
        [Required]
        public int drawers { get; set; }

        [Display(Name = "Surface Material")]
        [Required]
        public string surfaceMaterial { get; set; }

        [Display(Name = "Rush Days")]
        [Required]
        public int rushDelivery { get; set; }

        [Display(Name = "Quote Total")]
        public double total { get; set; }
    }
}
