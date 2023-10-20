using System.ComponentModel.DataAnnotations;

namespace Day9_Lab_Identity.ViewModels
{
    public class LoginAccountViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = " Remeber me")]
        public bool IsPersiste { get; set; }
    }
}
