using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcAppTest2.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "SpeakerName")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAdd { get; set; }

        [Display(Name = "Birth Day")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

       // public List<Session> Sessions { get; set; }
    }
}