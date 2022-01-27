using _72HourProj.Data.PostEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Data
{
    public class Comment
    {  
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        //public virtual ICollection<Reply> Reply { get; set; } = new List<Reply>();
    }
}
