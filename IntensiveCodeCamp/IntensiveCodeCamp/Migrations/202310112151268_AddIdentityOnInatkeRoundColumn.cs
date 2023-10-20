namespace IntensiveCodeCamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityOnInatkeRoundColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "IntakeRound", "dbo.Intakes");
            DropPrimaryKey("dbo.Intakes");
            AlterColumn("dbo.Intakes", "Round", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Intakes", "Round");
            AddForeignKey("dbo.Tracks", "IntakeRound", "dbo.Intakes", "Round");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "IntakeRound", "dbo.Intakes");
            DropPrimaryKey("dbo.Intakes");
            AlterColumn("dbo.Intakes", "Round", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Intakes", "Round");
            AddForeignKey("dbo.Tracks", "IntakeRound", "dbo.Intakes", "Round");
        }
    }
}
