using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [MinLength(3)]
        [Required]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(3)]
        public string LName { get; set; }

        [Display(Name ="Birth Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(3)]
        //[RegularExpression(@"^[a-zA-Z]{3},[a-zA-Z}{3}$",ErrorMessage ="The Address must be like Country,City")]
        public string Address { get; set; }
        public virtual List<Student_Course_Grade> Grades { get; set; }
    }
}