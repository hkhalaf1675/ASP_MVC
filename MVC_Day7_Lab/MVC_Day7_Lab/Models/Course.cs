using System;
using System.Collections.Generic;

namespace MVC_Day7_Lab.Models;

public partial class Course
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<StudentCourseGrade> StudentCourseGrades { get; set; } = new List<StudentCourseGrade>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
