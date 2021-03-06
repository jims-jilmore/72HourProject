using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Models.CommentModels
{
    public class CommentCreate
    {
        [Required]
        public int CommentId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Please enter a longer comment.")]
        public string Text { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
    }
}
