namespace CafeMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ParentCategoryID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatorUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatorUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductProperties",
                c => new
                    {
                        ProductPropertyID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PropertyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPropertyID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.PropertyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Username = c.String(),
                        HashPassword = c.String(),
                        SaltPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProductProperties", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.ProductProperties", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductProperties", new[] { "PropertyID" });
            DropIndex("dbo.ProductProperties", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.Properties");
            DropTable("dbo.ProductProperties");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
