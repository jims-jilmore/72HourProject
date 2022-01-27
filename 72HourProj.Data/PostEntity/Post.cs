using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Data.PostEntity
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public Guid AuthorId { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        //public virtual ICollection<Like> Likes { get; set; } = new List<Like>();  //<<<---Here in case we build a like model




    }
}
