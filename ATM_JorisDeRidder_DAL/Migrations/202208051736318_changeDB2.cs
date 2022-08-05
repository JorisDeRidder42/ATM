namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDB2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "TransactionID");
            DropColumn("dbo.Balances", "AccountID");
            DropColumn("dbo.Cards", "AccountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Balances", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "TransactionID", c => c.Int(nullable: false));
        }
    }
}
