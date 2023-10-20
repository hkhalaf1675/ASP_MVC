using System.ComponentModel.DataAnnotations;

namespace MVC_Day7_Lab.Models
{
    public sealed class StudentMetaData
    {
        [Display(Name ="First Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [RegularExpression(@"[a-zA-Z]")]
        public string Fname { get; set; } = null!;

        public string Lname { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string Address { get; set; } = null!;
    }
}
