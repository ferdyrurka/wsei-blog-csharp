using Blog.Entity;
using System.Collections.Generic;

namespace Blog.Repository
{
    public interface IPostRepository
    {
        public List<Post> FindAll();

        public void Save(Post post);
    }
}
