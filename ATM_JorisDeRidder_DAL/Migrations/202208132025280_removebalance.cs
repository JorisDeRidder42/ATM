namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removebalance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "BalanceID", "dbo.Balances");
            DropIndex("dbo.Accounts", new[] { "BalanceID" });
            DropColumn("dbo.Accounts", "BalanceID");
            DropTable("dbo.Balances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceID = c.Int(nullable: false, identity: true),
                        BalanceAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceID);
            
            AddColumn("dbo.Accounts", "BalanceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "BalanceID");
            AddForeignKey("dbo.Accounts", "BalanceID", "dbo.Balances", "BalanceID", cascadeDelete: true);
        }
    }
}
