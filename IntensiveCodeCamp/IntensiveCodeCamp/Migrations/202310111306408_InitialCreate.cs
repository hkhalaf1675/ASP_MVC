namespace IntensiveCodeCamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        Description = c.String(),
                        MaxDgree = c.Int(),
                        MinDgree = c.Int(),
                        TrackID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tracks", t => t.TrackID)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        IntakeRound = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Intakes", t => t.IntakeRound)
                .Index(t => t.IntakeRound);
            
            CreateTable(
                "dbo.Intakes",
                c => new
                    {
                        Round = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Round);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TrackID", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "IntakeRound", "dbo.Intakes");
            DropIndex("dbo.Tracks", new[] { "IntakeRound" });
            DropIndex("dbo.Courses", new[] { "TrackID" });
            DropTable("dbo.Intakes");
            DropTable("dbo.Tracks");
            DropTable("dbo.Courses");
        }
    }
}
