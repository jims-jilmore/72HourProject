namespace _72HourProj.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Comment_CommentId", c => c.Int());
            CreateIndex("dbo.Replies", "Comment_CommentId");
            AddForeignKey("dbo.Replies", "Comment_CommentId", "dbo.Comments", "CommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "Comment_CommentId", "dbo.Comments");
            DropIndex("dbo.Replies", new[] { "Comment_CommentId" });
            DropColumn("dbo.Replies", "Comment_CommentId");
        }
    }
}
