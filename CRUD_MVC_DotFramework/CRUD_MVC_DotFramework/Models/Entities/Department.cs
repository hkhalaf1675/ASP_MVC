using CRUD_MVC_DotFramework.Models.MetaDataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DeptName { get; set; }
        [ForeignKey("Instructor")]
        public int ManagerID { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
    }
}