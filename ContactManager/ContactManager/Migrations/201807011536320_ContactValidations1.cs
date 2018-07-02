namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactValidations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonContactInfoes", "id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.PersonContactInfoes");
            AddPrimaryKey("dbo.PersonContactInfoes", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonContactInfoes");
            AddPrimaryKey("dbo.PersonContactInfoes", "Id");
            AlterColumn("dbo.PersonContactInfoes", "id", c => c.Int(nullable: false, identity: true));
        }
    }
}
