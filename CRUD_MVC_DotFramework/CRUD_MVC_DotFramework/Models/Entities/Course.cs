using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Duration")]
        public short? CourseDuration { get; set; }
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
    }
}