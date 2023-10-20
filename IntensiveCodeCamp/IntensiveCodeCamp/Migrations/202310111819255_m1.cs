namespace IntensiveCodeCamp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 50, unicode: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Display",
                        new AnnotationValues(oldValue: null, newValue: "Course Name")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 50, unicode: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Display",
                        new AnnotationValues(oldValue: "Course Name", newValue: null)
                    },
                }));
        }
    }
}
