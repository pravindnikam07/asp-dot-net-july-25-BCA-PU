using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistrationValidationDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Full name must be between 3 and 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
        public int? Age { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8,
            ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password",
            ErrorMessage = "Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone number must contain exactly 10 digits and should be numbers.")]
        public string Phone { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Registration successful!";
            }
        }
    }
}
