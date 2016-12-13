namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Serialnumber = c.String(),
                        RegularMaintenance = c.Boolean(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TypeOfDeviceId = c.Int(nullable: false),
                        MediumId = c.Int(nullable: false),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.MediumId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfDevices", t => t.TypeOfDeviceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TypeOfDeviceId)
                .Index(t => t.MediumId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gas = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        Prename = c.String(),
                        Surname = c.String(),
                        Language = c.Int(nullable: false),
                        Phone = c.String(),
                        IndustryFamilyType = c.Int(nullable: false),
                        IndustryType = c.String(),
                        CompanyName = c.String(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        SecretQuestion = c.String(),
                        SecretAnswer = c.String(),
                        TermsAccepted = c.Boolean(nullable: false),
                        ConfirmationHash = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TagDevices",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Device_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Device_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.Device_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Device_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Devices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Devices", "TypeOfDeviceId", "dbo.TypeOfDevices");
            DropForeignKey("dbo.TagDevices", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.TagDevices", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Devices", "MediumId", "dbo.Media");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.TagDevices", new[] { "Device_Id" });
            DropIndex("dbo.TagDevices", new[] { "Tag_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropIndex("dbo.Devices", new[] { "MediumId" });
            DropIndex("dbo.Devices", new[] { "TypeOfDeviceId" });
            DropIndex("dbo.Devices", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TagDevices");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.TypeOfDevices");
            DropTable("dbo.Tags");
            DropTable("dbo.Media");
            DropTable("dbo.Devices");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
        }
    }
}
