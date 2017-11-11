namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ProductionYear = c.Int(nullable: false),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieShoppingCarts",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        ShoppingCart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.ShoppingCart_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.ShoppingCart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieShoppingCarts", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.MovieShoppingCarts", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieShoppingCarts", new[] { "ShoppingCart_Id" });
            DropIndex("dbo.MovieShoppingCarts", new[] { "Movie_Id" });
            DropTable("dbo.MovieShoppingCarts");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Movies");
        }
    }
}
