using _72HourProj.Data;
using _72HourProj.Models.CommentModels;
using _72HourProj.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Services.Services
{
    public class CommentService
    {
        private readonly Guid _authorID;

        public CommentService(Guid authorId)
        {
            _authorID = authorId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentId = model.CommentId,
                    AuthorId = _authorID,
                    Text = model.Text,
                    PostId = model.PostId,
                    

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;

            }

        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.AuthorId == _authorID )
                        .Select(
                            e =>
                            new CommentListItem
                            {
                                CommentId = e.CommentId,
                                PostId = e.Post.PostId,
                                Text = e.Text
                            }
                        );
                return query.ToArray();
            }
        }

       public CommentGet getCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.PostId =id);
                return
                    new Comment
                    {
                        CommentId = entity.CommentId,
                        PostId = entity.PostId,
                        Text = entity.Text
                    };
            }
        }
    }
}
