using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Range(5000.0,20000.0)]
        public double? Salary { get; set; }

        [MinLength(3)]
        public string Address { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}