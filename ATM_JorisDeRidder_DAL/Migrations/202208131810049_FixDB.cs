namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CardAccounts", new[] { "CardID" });
            DropIndex("dbo.CardAccounts", new[] { "AccountID" });
            AlterColumn("dbo.Cards", "CardName", c => c.String(nullable: false));
            AlterColumn("dbo.CardTypes", "CardTypeName", c => c.String(nullable: false));
            CreateIndex("dbo.CardAccounts", new[] { "CardID", "AccountID" }, unique: true, name: "IX_CardIDAccountID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CardAccounts", "IX_CardIDAccountID");
            AlterColumn("dbo.CardTypes", "CardTypeName", c => c.String());
            AlterColumn("dbo.Cards", "CardName", c => c.String());
            CreateIndex("dbo.CardAccounts", "AccountID");
            CreateIndex("dbo.CardAccounts", "CardID");
        }
    }
}
