using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Models.ReplyModels
{
    public class ReplyCreate
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public int CommentId { get; set; }
        
        [Required]
        [MaxLength(200, ErrorMessage = "Too many characters to reply.")]
        [MinLength(1, ErrorMessage = "No message to reply.")]
        public string ReplyMessage { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

     
    }
}
