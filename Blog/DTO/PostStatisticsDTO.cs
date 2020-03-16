using System.ComponentModel.DataAnnotations;

namespace Blog.DTO
{
    public class PostStatisticsDTO
    {
        [Required]
        public string PostId { get; set; }

        [Required]
        public int Views { get; set; }

        [Required]
        public int Conversions { get; set; }

        [Required]
        public double ReadTime { get; set; }
    }
}
