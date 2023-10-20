using System.ComponentModel.DataAnnotations;

namespace Day9_Lab_Identity.ViewModels
{
    public class RegisterAccountsViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)] 
        public string EmailAddress { get; set;}

        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
