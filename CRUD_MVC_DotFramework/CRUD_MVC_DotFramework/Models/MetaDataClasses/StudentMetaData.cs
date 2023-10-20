using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models.MetaDataClasses
{
    public class StudentMetaData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SSN { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(100,MinimumLength = 3)]
        [Required]
        public string FullName { get; set; }
        [Range(15, 50)]
        public int? Age { get; set; }
        [Range(1, 4)]
        public short Level { get; set; }
    }
}