namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        type = c.String(),
                        TransactionID = c.Int(nullable: false),
                        Card_CardID = c.Int(),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Transactions", t => t.TransactionID, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_CardID)
                .Index(t => t.TransactionID)
                .Index(t => t.Card_CardID);
            
            CreateTable(
                "dbo.ClientAccounts",
                c => new
                    {
                        ClientAccountID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientAccountID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => new { t.ClientID, t.AccountID }, unique: true, name: "IX_ClientIDAccountID");
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ClientName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false),
                        CardPassword = c.String(nullable: false),
                        FailedLogin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        Total_Amount = c.Int(nullable: false),
                        dateLog = c.DateTime(nullable: false),
                        Card_CardID = c.Int(),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Cards", t => t.Card_CardID)
                .Index(t => t.Card_CardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "Card_CardID", "dbo.Cards");
            DropForeignKey("dbo.Accounts", "Card_CardID", "dbo.Cards");
            DropForeignKey("dbo.Accounts", "TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.ClientAccounts", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.ClientAccounts", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Logs", new[] { "Card_CardID" });
            DropIndex("dbo.ClientAccounts", "IX_ClientIDAccountID");
            DropIndex("dbo.Accounts", new[] { "Card_CardID" });
            DropIndex("dbo.Accounts", new[] { "TransactionID" });
            DropTable("dbo.Logs");
            DropTable("dbo.Cards");
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAccounts");
            DropTable("dbo.Accounts");
        }
    }
}
