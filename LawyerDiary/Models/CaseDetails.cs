using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerDiary.Models
{
    public class CaseDetails
    {

        public int id { get; set; }

        [Display(Name = " Client Name")]
        public string MName { get; set; }

        [Display(Name = "Case Type")]
        public string LType { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }

        public Lawyer lawyer { get; set; }


    }
}
