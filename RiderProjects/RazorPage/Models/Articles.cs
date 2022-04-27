using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPage.Models;
[Table("acticles")]
public class Articles
{
    [Key]
    [DisplayName("Id")]
    public int ArticleId { get; set; }
    [DisplayName("Tiêu đề bài viết")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} co do dai tu {2} den {1}")]
    public string ArticleTitle { get; set; }
    [DisplayName("Nội dung bài viết")]
    [Column(TypeName = "ntext")]
    public string ArticleContent { get; set; }

    [DisplayName("Ngày đăng")]
    [DataType(DataType.DateTime)]
    [Column("ArticleCreatedAt")]
    public DateTime ArticleCreatedAt { get; set; }
}