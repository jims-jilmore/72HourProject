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

        public IEnumerable<CommentListItem> GetCommentsByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.PostId == id)
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

        
    }
}
