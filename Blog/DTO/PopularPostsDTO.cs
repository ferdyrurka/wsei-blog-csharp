using System.ComponentModel.DataAnnotations;

namespace Blog.DTO
{
    public class PopularPostsDTO
    {
        [Required]
        public PostStatisticsDTO[] PostsStatistics { get; set; }
    }
}
