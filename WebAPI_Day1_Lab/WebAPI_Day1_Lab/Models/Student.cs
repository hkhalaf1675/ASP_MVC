using System.ComponentModel.DataAnnotations;

namespace WebAPI_Day1_Lab.Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(50,MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 2)]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [Range(10,50)]
        public int Age { get; set; }
    }
}
