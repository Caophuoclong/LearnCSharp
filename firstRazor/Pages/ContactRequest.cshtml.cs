using Microsoft.AspNetCore.Mvc.RazorPages;
using firstRazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace firstRazor.Pages
{
    public class ContactRequestModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public ContactRequestModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [BindProperty]
        public UserContact userContact { get; set; }
        [BindProperty]
        [DisplayName("Chon avatar")]
        [DataType(DataType.Upload)]
        public IFormFile FileUpload { get; set; }
        public void OnPost()
        {
            System.Console.WriteLine(_environment.WebRootPath);
            if (FileUpload != null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, "upload", FileUpload.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                FileUpload.CopyTo(fileStream);
            }


        }
    }
}