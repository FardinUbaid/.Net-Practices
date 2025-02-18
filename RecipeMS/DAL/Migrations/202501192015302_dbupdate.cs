namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        RatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Ingredients = c.String(),
                        Instructions = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Recipes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Recipes", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "RecipeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ratings");
        }
    }
}
