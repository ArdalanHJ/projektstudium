namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIEntityToMediumAndTypeOfDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "Timestamp_Created", c => c.DateTime());
            AddColumn("dbo.Media", "Timestamp_Deleted", c => c.DateTime());
            AddColumn("dbo.Media", "Timestamp_Modified", c => c.DateTime());
            AddColumn("dbo.TypeOfDevices", "Timestamp_Created", c => c.DateTime());
            AddColumn("dbo.TypeOfDevices", "Timestamp_Deleted", c => c.DateTime());
            AddColumn("dbo.TypeOfDevices", "Timestamp_Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeOfDevices", "Timestamp_Modified");
            DropColumn("dbo.TypeOfDevices", "Timestamp_Deleted");
            DropColumn("dbo.TypeOfDevices", "Timestamp_Created");
            DropColumn("dbo.Media", "Timestamp_Modified");
            DropColumn("dbo.Media", "Timestamp_Deleted");
            DropColumn("dbo.Media", "Timestamp_Created");
        }
    }
}
