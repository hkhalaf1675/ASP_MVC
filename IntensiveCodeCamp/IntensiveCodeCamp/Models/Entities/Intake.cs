using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.Entities
{
    public class Intake
    {
        [Key]
        [Display(Name = "Intake Round")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Round { get; set; }
        [Display(Name = "Intake Name")]
        [StringLength(100,MinimumLength =2)]
        public string Name { get; set; }
        [InverseProperty("Intake")]
        public List<Track> Tracks { get; set; }
    }
}