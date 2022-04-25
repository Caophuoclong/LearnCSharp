using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace firstRazor.Models
{
    public class UserContact
    {
        [DisplayName("Id cua ban")]
        [Required(ErrorMessage = "Bat buoc nhap")]
        [Range(1, 100, ErrorMessage = "Id khong hop le")]
        public int UserId { get; set; }
        [DisplayName("Ten tai khoan")]
        [Required(ErrorMessage = "Bat buoc nhap")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} phai dai tu {1} - {2}")]
        public string UserName { get; set; }
        [DisplayName("Ho va ten")]
        public string? FName { get; set; }
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email khong hop le")]
        public string? Email { get; set; }
    }
}