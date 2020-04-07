using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]
        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_ ]+$"), Required, StringLength(30)]
        public string Topic { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingID { get; set; }
        public Meeting Meeting { get; set; }
    }
}
