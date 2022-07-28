namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbalance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceID = c.Int(nullable: false, identity: true),
                        BalanceAmount = c.Int(nullable: false),
                        CardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceID);
            
            AddColumn("dbo.Cards", "Balance_BalanceID", c => c.Int());
            CreateIndex("dbo.Cards", "Balance_BalanceID");
            AddForeignKey("dbo.Cards", "Balance_BalanceID", "dbo.Balances", "BalanceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Balance_BalanceID", "dbo.Balances");
            DropIndex("dbo.Cards", new[] { "Balance_BalanceID" });
            DropColumn("dbo.Cards", "Balance_BalanceID");
            DropTable("dbo.Balances");
        }
    }
}
