using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.Entities
{
    public class Track
    {
        public int ID { get; set; }
        [Display(Name = "Track Name")]
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string Name { get; set; }
        [ForeignKey("Intake")]
        [Display(Name = "Intake")]
        public int? IntakeRound { get; set; }
        [InverseProperty("Tracks")]
        public Intake Intake { get; set; }
        [InverseProperty("Track")]
        public List<Course> Courses { get; set; }
    }
}