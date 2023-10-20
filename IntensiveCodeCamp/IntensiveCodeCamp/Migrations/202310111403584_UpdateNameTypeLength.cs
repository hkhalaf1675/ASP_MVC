namespace IntensiveCodeCamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameTypeLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Tracks", "Name", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "Name", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
