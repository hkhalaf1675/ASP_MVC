﻿namespace IntensiveCodeCamp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Display",
                        new AnnotationValues(oldValue: "Course Name", newValue: null)
                    },
                }));
            AlterColumn("dbo.Tracks", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Intakes", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Intakes", "Name", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Tracks", "Name", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 50, unicode: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Display",
                        new AnnotationValues(oldValue: null, newValue: "Course Name")
                    },
                }));
        }
    }
}
