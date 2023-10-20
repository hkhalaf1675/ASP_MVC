using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    public class Student_Course_Grade
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        [Range(0.0f,4.0f)]
        public float Grade { get; set; }
    }
}