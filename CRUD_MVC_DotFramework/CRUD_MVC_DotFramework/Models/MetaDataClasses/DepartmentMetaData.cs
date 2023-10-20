using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models.MetaDataClasses
{
    public class DepartmentMetaData
    {
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
        [Display(Name ="Manager")]
        [ForeignKey("Instructor")]
        public int ManagerID { get; set; }
    }
}