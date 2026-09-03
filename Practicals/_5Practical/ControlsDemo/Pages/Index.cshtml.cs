using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControlsDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string StudentName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
            Message = "Please enter your name and click Submit.";
        }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(StudentName))
            {
                Message = $"Welcome, {StudentName}!";
            }
            else
            {
                Message = "Please enter your name.";
            }
        }
    }
}
