using System;
using System.ComponentModel.DataAnnotations;
namespace learncsharp

{
    public class User
    {
        [Required(ErrorMessage = "Name must be not empty")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Length of name must be greater than 5 and less than 100 characters")]
        public string name { get; set; } = "";
        [Required(ErrorMessage = "Age must be not empty!")]
        [Range(18, 60, ErrorMessage = "Age must be in range 18 and 60")]
        public int age { get; set; }
        public string GetInfo()
        {
            return $"Name: {this.name} - Tuoi: {this.age}";
        }
    }
}