using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Models.PostModels
{
    public class EditPost
    {
        public int PostId { get; set; }

        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        [Display(Name = "Content")]
        public string PostContent { get; set; }

    }
}
