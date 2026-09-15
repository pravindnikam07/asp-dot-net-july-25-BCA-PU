
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListBoxDropDownDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SelectedCity { get; set; } = string.Empty;

        [BindProperty]
        public List<string> SelectedSkills { get; set; } = new();

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }
    }
}
