using _72HourProj.Models.PostModels;
using _72HourProj.Data.PostEntity;
using _72HourProj.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourProj.Services.Services
{
    public class PostService
    {
        public PostService() { }

        private readonly Guid _authorId;
        
        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePost(PostCreate model)
        {
            Post entity =
                new Post()
                {
                    AuthorId = _authorId,
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    CreatedUtc = DateTimeOffset.Now                    
                };
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetAllPosts> GetPosts()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(p => p.AuthorId == _authorId)
                    .Select(p => new GetAllPosts()
                    {
                        PostId = p.PostId,
                        PostTitle = p.PostTitle,
                        PostContent = p.PostContent,
                        CreatedUtc = p.CreatedUtc
                    });
                return query.ToArray();
            }
        }

        public PostDetail GetPostByAuthorId(
            int authId)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Post entity =
                    ctx
                    .Posts
                    .Single(p => p.PostId == authId && p.AuthorId == _authorId);
                return
                    new PostDetail()
                    {
                        PostId = entity.PostId,
                        PostTitle = entity.PostTitle,
                        PostContent= entity.PostContent,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdatePost(EditPost model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
               var entity =
                    ctx
                    .Posts
                    .Single(p => p.PostId == model.PostId && p.AuthorId == _authorId);
                entity.PostId = model.PostId;
                entity.PostTitle = model.PostTitle; 
                entity.PostContent = model.PostContent;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Post Entity =
                    ctx
                    .Posts
                    .Single(p => p.PostId == postId && p.AuthorId == _authorId);

                ctx.Posts.Remove(Entity);

                return ctx.SaveChanges() == 1;
            }
        }
        

    }
}
