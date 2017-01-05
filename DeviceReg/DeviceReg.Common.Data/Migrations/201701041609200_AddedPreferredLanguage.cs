namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPreferredLanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "PreferredLanguage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "PreferredLanguage");
        }
    }
}
