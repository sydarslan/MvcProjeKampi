namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactdateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
