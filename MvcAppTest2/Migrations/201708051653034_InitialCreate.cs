namespace MvcAppTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Sessions", t => t.SessionID, cascadeDelete: true)
                .Index(t => t.SessionID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Abstract = c.String(nullable: false),
                        SpeakerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Speakers", t => t.SpeakerID, cascadeDelete: true)
                .Index(t => t.SpeakerID);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        SpeakerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmailAdd = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SpeakerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "SpeakerID", "dbo.Speakers");
            DropForeignKey("dbo.Comments", "SessionID", "dbo.Sessions");
            DropIndex("dbo.Sessions", new[] { "SpeakerID" });
            DropIndex("dbo.Comments", new[] { "SessionID" });
            DropTable("dbo.Speakers");
            DropTable("dbo.Sessions");
            DropTable("dbo.Comments");
        }
    }
}
