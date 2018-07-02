namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonContactInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PersonContactInfoes", "FistName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.PersonContactInfoes", "LastName", c => c.String(nullable: false, maxLength: 255));
            DropPrimaryKey("dbo.PersonContactInfoes");
            AddPrimaryKey("dbo.PersonContactInfoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonContactInfoes");
            AddPrimaryKey("dbo.PersonContactInfoes", "id");
            AlterColumn("dbo.PersonContactInfoes", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.PersonContactInfoes", "FistName", c => c.String(nullable: false));
            AlterColumn("dbo.PersonContactInfoes", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
