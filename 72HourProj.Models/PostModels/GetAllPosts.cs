using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Models.PostModels
{
    public class GetAllPosts
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
