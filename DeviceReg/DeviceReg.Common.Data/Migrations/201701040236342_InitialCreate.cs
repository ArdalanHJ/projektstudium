namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TextResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lang = c.String(),
                        Text = c.String(),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextResources");
        }
    }
}
