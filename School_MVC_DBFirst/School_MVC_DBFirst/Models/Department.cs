using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = " Department Name")]
        [MinLength(2)]
        public string Name { get; set; }
        public virtual Instructor Manager { get; set; }
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public virtual List<Instructor> instructors { get; set; }
    }
}