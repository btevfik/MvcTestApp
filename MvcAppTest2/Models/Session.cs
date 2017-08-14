using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAppTest2.Models
{
    public class Session
    {
        public int SessionId { get; set;}

        [Required()]
        public string Title {get; set; }

        [Required()]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        public int SpeakerID { get; set; }

        public virtual Speaker Speaker { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}