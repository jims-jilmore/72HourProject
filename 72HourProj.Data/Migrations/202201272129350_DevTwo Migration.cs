namespace _72HourProj.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DevTwoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        ReplyMessage = c.String(nullable: false, maxLength: 200),
                        AuthorId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            AddColumn("dbo.Comments", "Reply_ReplyId", c => c.Int());
            CreateIndex("dbo.Comments", "Reply_ReplyId");
            AddForeignKey("dbo.Comments", "Reply_ReplyId", "dbo.Replies", "ReplyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Reply_ReplyId", "dbo.Replies");
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropIndex("dbo.Replies", new[] { "CommentId" });
            DropIndex("dbo.Comments", new[] { "Reply_ReplyId" });
            DropColumn("dbo.Comments", "Reply_ReplyId");
            DropTable("dbo.Replies");
        }
    }
}
