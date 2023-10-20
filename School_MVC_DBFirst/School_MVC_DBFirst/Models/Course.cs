using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    public class Course
    {
        [Key]
        [MaxLength(5),MinLength(3)]
        [Required]
        [Display(Name = "Course Code")]
        public string Code { get; set; }

        [Display(Name = "Course Name")]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(minimum:1,maximum:5)]
        [Required]
        public int? Duration { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<Student_Course_Grade> Grades { get; set; }

    }
}