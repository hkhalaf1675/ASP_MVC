using School_MVC_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.ViewModel
{
    public class DepartmentInstructors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
    }
}