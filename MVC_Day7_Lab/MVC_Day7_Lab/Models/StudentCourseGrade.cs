using System;
using System.Collections.Generic;

namespace MVC_Day7_Lab.Models;

public partial class StudentCourseGrade
{
    public int Id { get; set; }

    public float Grade { get; set; }

    public string? CourseCode { get; set; }

    public int? StudentId { get; set; }

    public virtual Course? CourseCodeNavigation { get; set; }

    public virtual Student? Student { get; set; }
}
