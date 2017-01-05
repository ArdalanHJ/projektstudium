namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSerialNumberToIndex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "Serialnumber", c => c.String(maxLength: 9));
            CreateIndex("dbo.Devices", "Serialnumber", unique: true, name: "SerialNumberIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Devices", "SerialNumberIndex");
            AlterColumn("dbo.Devices", "Serialnumber", c => c.String());
        }
    }
}
