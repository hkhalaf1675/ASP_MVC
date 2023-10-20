using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.Entities
{
    public class Course
    {
        public int ID { get; set; }
        [Display(Name = "Course Name")]
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(10,100)]
        [Required]
        public int? MaxDgree { get; set; }
        [Range(0,90)]
        [Required]
        public int? MinDgree { get; set; }
        [ForeignKey("Track")]
        [Display(Name = "Track")]
        public int? TrackID { get; set; }
        [InverseProperty("Courses")]
        public Track Track { get; set; }

    }
}