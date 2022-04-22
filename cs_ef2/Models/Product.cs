using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cs_ef2.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public void PrintData()
        {
            Console.WriteLine($"{ProductId,3} {ProductName,20} {Price.ToString("#.##"),5} {CategoryId,2}");

        }
    }
}