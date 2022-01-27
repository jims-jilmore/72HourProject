using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Models.ReplyModels
{
    public class ReplyGet
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public string ReplyMessage { get; set; }

        //public ICollection<Comment> Comment { get; set; }
    }
}
