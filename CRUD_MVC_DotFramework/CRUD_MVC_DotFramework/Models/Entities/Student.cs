using CRUD_MVC_DotFramework.Models.MetaDataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public class Student
    {
        public int SSN { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public short Level { get; set; }
    }
}