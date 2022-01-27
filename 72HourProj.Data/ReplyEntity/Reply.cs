using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Data.ReplyEntity
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required, Display(Name = "Reply")]
        [MaxLength(200, ErrorMessage = "Too many characters to reply.")]
        [MinLength(1, ErrorMessage = "No message to reply.")]
        public string ReplyMessage { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey("Comment"), Required]
        public int CommentId { get; set; }
        //public virtual Comment Comment { get; set; }

       // public ICollection<Comment> Comment { get; set; } = new List<Comment>();
    }
}
