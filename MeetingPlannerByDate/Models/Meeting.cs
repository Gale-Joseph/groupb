using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPlanner.Models
{
    public class Meeting
    {
       // public int MeetingID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingID { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]

        public string Conducting { get; set; }


        [Display(Name = "Open Hymn")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]

        public string OpenHymn { get; set; }

        [Display(Name = "Open Prayer")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]

        public string OpenPrayer { get; set; }

        [Display(Name = "Sacrament Hymn")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]

        public string SacramentHymn { get; set; }

        [Display(Name = "Middle Hymn")]

        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), StringLength(30)]

        public string MiddleHymn { get; set; }

        [Display(Name = "Close Hymn")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]

        public string CloseHymn { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]
        [Display(Name = "Close Prayer")]

        public string ClosePrayer { get; set; }

        
        public List<Speaker>Speakers { get; set; }
    }
}
