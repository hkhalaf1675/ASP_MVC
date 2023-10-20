using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.Configrations
{
    public class IntakeConfigrations:EntityTypeConfiguration<Intake>
    {
        public IntakeConfigrations()
        {
            this.HasKey(I => I.Round);

            this.Property(I => I.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}