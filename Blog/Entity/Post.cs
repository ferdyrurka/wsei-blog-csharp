using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entity
{
    [Table("post")]
    public class Post
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(256)]
        [Column(TypeName = "varchar(256)")]
        public string title { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string content { get; set; }
    }
}
