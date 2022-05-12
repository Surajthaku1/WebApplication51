namespace WebApplication51.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Descr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Myproperty = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.category_Id)
                .Index(t => t.category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "category_Id", "dbo.categories");
            DropIndex("dbo.products", new[] { "category_Id" });
            DropTable("dbo.products");
            DropTable("dbo.categories");
        }
    }
}
