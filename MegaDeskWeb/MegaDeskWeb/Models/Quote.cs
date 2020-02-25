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
        public DateTime quoteDate { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int width { get; set; }
        public int depth { get; set; }
        public int drawers { get; set; }
        public string surfaceMaterial { get; set; }
        public int rushDelivery { get; set; }
        public double total { get; set; }
    }
}
