using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_MVC.Models
{
    public class Student
    {
        [Range(1,100)]
        public int ID { get; set; }

        [RegularExpression(@"^[a-zA-z]{3,}")]
        public string Name { get; set; }

        [Range(15,100)]
        public int Age { get; set; }

        public string Gender { get; set; }
        public string Image { get; set; }
    }
}