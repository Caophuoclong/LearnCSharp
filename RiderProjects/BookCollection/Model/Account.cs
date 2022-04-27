using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCollection.Model;

public class Account
{
    [Key]
    [Column("account_id")]
    public int Id { get; set; }
    [DisplayName("Tài khoản")]
    public string userName { get; set; }
    [DisplayName("Mật khẩu")]
    public string password { get; set; }
    public string salt { get; set; }
}