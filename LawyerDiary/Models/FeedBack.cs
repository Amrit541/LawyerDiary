using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerDiary.Models
{
    public class FeedBack
    {

        public int id { get; set; }

        [Display(Name = " Name")]
        public string MName { get; set; }

       
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Message")]
        public string Message { get; set; }

        public Lawyer lawyer { get; set; }

    }
}
