namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "AccountID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "AccountID");
        }
    }
}
