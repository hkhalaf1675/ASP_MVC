using System;
using System.Collections.Generic;

namespace MVC_Day8_Lab.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double? Salary { get; set; }

    public string? Address { get; set; }

    public int? DepartmentId { get; set; }

    public int? DepartmentId1 { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Department? DepartmentId1Navigation { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Course> CourseCodes { get; set; } = new List<Course>();
}
