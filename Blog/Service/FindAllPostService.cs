using Blog.Entity;
using Blog.Repository;
using System.Collections.Generic;

namespace Blog.Service
{
    public class FindAllPostService
    {
        private IPostRepository postRepository;

        public FindAllPostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public List<Post> FindAll()
        {
            return postRepository.FindAll();
        }
    }
}
