using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Models.PostModels
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Enter At Least 1 Character")]
        [MaxLength(100, ErrorMessage = "Title Can't Exceed 100 Characters")]
        public string PostTitle { get; set; }

        [Required]
        [MaxLength(5000, ErrorMessage = "Post Text Can't Exceed 5000 Characters")]
        public string PostText { get; set; }
        public string PostContent { get; set; }
    }
}
