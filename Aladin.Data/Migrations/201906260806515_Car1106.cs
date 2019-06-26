namespace Aladin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car1106 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        CountryID = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CustomerFood",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FoodID = c.Guid(nullable: false),
                        CustomerID = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IDNumber = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        CountryID = c.Guid(nullable: false),
                        CityID = c.Guid(nullable: false),
                        Address = c.String(),
                        Notes = c.String(),
                        IdentityDocument = c.Int(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Aladin.File",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        GuidName = c.Guid(nullable: false),
                        Path = c.String(),
                        ContentType = c.String(),
                        Extension = c.String(),
                        Size = c.Int(nullable: false),
                        ReferenceGuid = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Category = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "General.Info",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Location = c.String(),
                        Message = c.String(),
                        Type = c.Int(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "General.Log",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        LogLevel = c.Int(nullable: false),
                        Location = c.String(),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CorrelationId = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RoomID = c.Guid(nullable: false),
                        CustomerID = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        Fee = c.Double(nullable: false),
                        Paid = c.Double(nullable: false),
                        Entry = c.DateTime(nullable: false),
                        Departure = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Authentication.Role",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Authentication.UserInRole",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Authentication.User",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IdentificationNumber = c.String(maxLength: 1000),
                        Phone = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.IdentificationNumber, unique: true);
            
            CreateTable(
                "Authentication.ViewInRole",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        Controller = c.String(),
                        Action = c.String(),
                        Area = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("Authentication.User", new[] { "IdentificationNumber" });
            DropTable("Authentication.ViewInRole");
            DropTable("Authentication.User");
            DropTable("Authentication.UserInRole");
            DropTable("dbo.Room");
            DropTable("Authentication.Role");
            DropTable("dbo.Reservation");
            DropTable("General.Log");
            DropTable("General.Info");
            DropTable("dbo.Food");
            DropTable("Aladin.File");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerFood");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Category");
        }
    }
}
