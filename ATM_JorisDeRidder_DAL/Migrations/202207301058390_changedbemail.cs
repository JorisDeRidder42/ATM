namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedbemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ClientEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "ClientEmail");
        }
    }
}
