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

        public bool CreatePost(PostCreate model)
        {
            Post entity =
                new Post()
                {
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

    }
}
