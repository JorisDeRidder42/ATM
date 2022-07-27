namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "TransactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "TransactionID", c => c.Int(nullable: false));
        }
    }
}
