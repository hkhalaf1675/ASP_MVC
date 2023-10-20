namespace IntensiveCodeCamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCourseTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "MaxDgree", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "MinDgree", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "MinDgree", c => c.Int());
            AlterColumn("dbo.Courses", "MaxDgree", c => c.Int());
        }
    }
}
