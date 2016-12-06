namespace ProductWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        Review_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Review", t => t.Review_Id)
                .Index(t => t.Review_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50, unicode: false),
                        shortdescription = c.String(nullable: false, maxLength: 255, unicode: false),
                        Image = c.Binary(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Brand_Id = c.Int(),
                        Category_Id = c.Int(),
                        SubCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.Brand_Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.SubCategory", t => t.SubCategory_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.SubCategory_Id);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 150),
                        AddedDate = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SubCategory_Id", "dbo.SubCategory");
            DropForeignKey("dbo.Review", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Comment", "Review_Id", "dbo.Review");
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Product", "Brand_Id", "dbo.Brand");
            DropForeignKey("dbo.SubCategory", "Category_Id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "SubCategory_Id" });
            DropIndex("dbo.Review", new[] { "Product_Id" });
            DropIndex("dbo.Comment", new[] { "Review_Id" });
            DropIndex("dbo.Product", new[] { "Category_Id" });
            DropIndex("dbo.Product", new[] { "Brand_Id" });
            DropIndex("dbo.SubCategory", new[] { "Category_Id" });
            DropTable("dbo.Review");
            DropTable("dbo.Product");
            DropTable("dbo.Comment");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Category");
            DropTable("dbo.Brand");
        }
    }
}
