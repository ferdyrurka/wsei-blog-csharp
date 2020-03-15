using Blog.Repository;
using Blog.Entity;

namespace Blog.Service
{
    public class AddPostService
    {
        private IPostRepository PostRepository;

        public AddPostService(IPostRepository PostRepository)
        {
            this.PostRepository = PostRepository;
        }

        public void Create(Post post)
        {
           PostRepository.Save(post);
        }
    }
}
