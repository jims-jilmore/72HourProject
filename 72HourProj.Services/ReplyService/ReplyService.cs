using _72HourProj.Data;
using _72HourProj.Data.ReplyEntity;
using _72HourProj.Models;
using _72HourProj.Models.ReplyModels;
using _72HourProj.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Services.ReplyService
{
    public class ReplyService
    {
        private readonly Guid _authorId;
        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    ReplyId = model.ReplyId,
                    ReplyMessage = model.ReplyMessage,
                    AuthorId = _authorId,
                    CommentId = model.CommentId,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            CommentId = e.CommentId,
                            ReplyMessage = e.ReplyMessage,
                        }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<ReplyListItem> GetRepliesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.CommentId == id)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            CommentId = e.CommentId,
                            ReplyMessage = e.ReplyMessage
                        });
                return query.ToArray();
            }
        }
    }
}
