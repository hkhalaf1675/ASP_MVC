using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_MVC_DotFramework.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SSN { get; set; }

        [StringLength(100,MinimumLength = 3)]
        [Required]
        [Display(Name = "Instructor Name")]
        public string FullName{ get; set; }

        [Display(Name ="Department")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}