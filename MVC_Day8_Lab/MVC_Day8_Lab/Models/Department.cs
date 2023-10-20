using System;
using System.Collections.Generic;

namespace MVC_Day8_Lab.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime HiringDate { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Instructor> InstructorDepartmentId1Navigations { get; set; } = new List<Instructor>();

    public virtual ICollection<Instructor> InstructorDepartments { get; set; } = new List<Instructor>();

    public virtual Instructor? Manager { get; set; }
}
