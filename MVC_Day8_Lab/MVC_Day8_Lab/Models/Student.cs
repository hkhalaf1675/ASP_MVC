using System;
using System.Collections.Generic;

namespace MVC_Day8_Lab.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<StudentCourseGrade> StudentCourseGrades { get; set; } = new List<StudentCourseGrade>();
}
