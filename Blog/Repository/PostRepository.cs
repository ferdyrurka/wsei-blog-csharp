using Blog.Entity;
using Blog.Context;
using System.Linq;
using System.Collections.Generic;

namespace Blog.Repository
{
    public class PostRepository : IPostRepository
    {
        private PostContext context;

        public PostRepository(PostContext postContext)
        {
            this.context = postContext;
        }

        public List<Post> FindAll()
        {
            return context.Post.ToList<Post>();
        }

        public void Save(Post post)
        {
            context.Post.Add(post);
            context.SaveChanges();
        }
    }
}
