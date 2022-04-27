using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCollection.Model;

public class User
{
    [Key]
    [Column("user_id")]
    public int Id { get; set; }
    [DisplayName("Họ và tên")]
    public string fullName { get; set; }
    [DisplayName("Địa chỉ")]
    public string address { get; set; }
    [DisplayName("Địa chỉ email")]
    public string email { get; set; }

    public int? _accountId { get; set; }

    [ForeignKey("_accountId")]
    public Account _account { get; set; }
}