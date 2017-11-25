namespace PizzaMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        BranchName = c.String(),
                        CompanyName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BranchID)
                .ForeignKey("dbo.Company", t => t.CompanyName)
                .Index(t => t.CompanyName);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128),
                        CompanyDesc = c.String(),
                    })
                .PrimaryKey(t => t.CompanyName);
            
            CreateTable(
                "dbo.PizzaTypeCompany",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128),
                        PizzaTypeID = c.String(nullable: false, maxLength: 128),
                        PizzaType_PizzaTypeID = c.Int(),
                    })
                .PrimaryKey(t => new { t.CompanyName, t.PizzaTypeID })
                .ForeignKey("dbo.Company", t => t.CompanyName, cascadeDelete: true)
                .ForeignKey("dbo.PizzaType", t => t.PizzaType_PizzaTypeID)
                .Index(t => t.CompanyName)
                .Index(t => t.PizzaType_PizzaTypeID);
            
            CreateTable(
                "dbo.PizzaType",
                c => new
                    {
                        PizzaTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        PriceRangeMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceRangeMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxIngredients = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaTypeID);
            
            CreateTable(
                "dbo.PizzaTypeList",
                c => new
                    {
                        CouponID = c.Int(nullable: false),
                        PizzaTypeID = c.String(nullable: false, maxLength: 128),
                        PizzaType_PizzaTypeID = c.Int(),
                    })
                .PrimaryKey(t => new { t.CouponID, t.PizzaTypeID })
                .ForeignKey("dbo.Coupon", t => t.CouponID, cascadeDelete: true)
                .ForeignKey("dbo.PizzaType", t => t.PizzaType_PizzaTypeID)
                .Index(t => t.CouponID)
                .Index(t => t.PizzaType_PizzaTypeID);
            
            CreateTable(
                "dbo.Coupon",
                c => new
                    {
                        CouponID = c.Int(nullable: false, identity: true),
                        CouponName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Delivery = c.Boolean(nullable: false),
                        CouponCode = c.String(),
                        CouponType = c.Int(nullable: false),
                        PercentDisc = c.Int(nullable: false),
                        PriceTwoForOne = c.Int(nullable: false),
                        NoOfPizzasTwoForOne = c.Int(nullable: false),
                        FixedDisc = c.Int(nullable: false),
                        MinPriceFixedDisc = c.Int(nullable: false),
                        NoOfSides = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CouponID);
            
            CreateTable(
                "dbo.CouponRelation",
                c => new
                    {
                        BranchID = c.Int(nullable: false),
                        CouponID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BranchID, t.CouponID })
                .ForeignKey("dbo.Branch", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.Coupon", t => t.CouponID, cascadeDelete: true)
                .Index(t => t.BranchID)
                .Index(t => t.CouponID);
            
            CreateTable(
                "dbo.Side",
                c => new
                    {
                        SideID = c.Int(nullable: false, identity: true),
                        SideName = c.String(),
                        SideDesc = c.String(),
                        Coupon_CouponID = c.Int(),
                    })
                .PrimaryKey(t => t.SideID)
                .ForeignKey("dbo.Coupon", t => t.Coupon_CouponID)
                .Index(t => t.Coupon_CouponID);
            
            CreateTable(
                "dbo.SideList",
                c => new
                    {
                        SideID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SideID, t.CompanyName })
                .ForeignKey("dbo.Company", t => t.CompanyName, cascadeDelete: true)
                .ForeignKey("dbo.Side", t => t.SideID, cascadeDelete: true)
                .Index(t => t.SideID)
                .Index(t => t.CompanyName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaTypeList", "PizzaType_PizzaTypeID", "dbo.PizzaType");
            DropForeignKey("dbo.Side", "Coupon_CouponID", "dbo.Coupon");
            DropForeignKey("dbo.SideList", "SideID", "dbo.Side");
            DropForeignKey("dbo.SideList", "CompanyName", "dbo.Company");
            DropForeignKey("dbo.PizzaTypeList", "CouponID", "dbo.Coupon");
            DropForeignKey("dbo.CouponRelation", "CouponID", "dbo.Coupon");
            DropForeignKey("dbo.CouponRelation", "BranchID", "dbo.Branch");
            DropForeignKey("dbo.PizzaTypeCompany", "PizzaType_PizzaTypeID", "dbo.PizzaType");
            DropForeignKey("dbo.PizzaTypeCompany", "CompanyName", "dbo.Company");
            DropForeignKey("dbo.Branch", "CompanyName", "dbo.Company");
            DropIndex("dbo.SideList", new[] { "CompanyName" });
            DropIndex("dbo.SideList", new[] { "SideID" });
            DropIndex("dbo.Side", new[] { "Coupon_CouponID" });
            DropIndex("dbo.CouponRelation", new[] { "CouponID" });
            DropIndex("dbo.CouponRelation", new[] { "BranchID" });
            DropIndex("dbo.PizzaTypeList", new[] { "PizzaType_PizzaTypeID" });
            DropIndex("dbo.PizzaTypeList", new[] { "CouponID" });
            DropIndex("dbo.PizzaTypeCompany", new[] { "PizzaType_PizzaTypeID" });
            DropIndex("dbo.PizzaTypeCompany", new[] { "CompanyName" });
            DropIndex("dbo.Branch", new[] { "CompanyName" });
            DropTable("dbo.SideList");
            DropTable("dbo.Side");
            DropTable("dbo.CouponRelation");
            DropTable("dbo.Coupon");
            DropTable("dbo.PizzaTypeList");
            DropTable("dbo.PizzaType");
            DropTable("dbo.PizzaTypeCompany");
            DropTable("dbo.Company");
            DropTable("dbo.Branch");
        }
    }
}
