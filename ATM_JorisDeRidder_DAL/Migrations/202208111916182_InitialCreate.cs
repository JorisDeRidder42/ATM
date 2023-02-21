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
                        AccountName = c.String(nullable: false),
                        AccountAmount = c.Int(nullable: false),
                        BalanceID = c.Int(nullable: false),
                        TransactionID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Balances", t => t.BalanceID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.TransactionID, cascadeDelete: true)
                .Index(t => t.BalanceID)
                .Index(t => t.TransactionID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceID = c.Int(nullable: false, identity: true),
                        BalanceAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceID);
            
            CreateTable(
                "dbo.CardAccounts",
                c => new
                    {
                        CardAccountID = c.Int(nullable: false, identity: true),
                        CardID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardAccountID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.CardID, cascadeDelete: true)
                .Index(t => t.CardID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        CardName = c.String(),
                        CardTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.CardTypes", t => t.CardTypeID, cascadeDelete: true)
                .Index(t => t.CardTypeID);
            
            CreateTable(
                "dbo.CardTypes",
                c => new
                    {
                        CardTypeID = c.Int(nullable: false, identity: true),
                        CardTypeName = c.String(),
                    })
                .PrimaryKey(t => t.CardTypeID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ClientName = c.String(nullable: false),
                        ClientEmail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        BirthDate = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionAmount = c.Int(nullable: false),
                        TransactionTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeID, cascadeDelete: true)
                .Index(t => t.TransactionTypeID);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransActionTypeID = c.Int(nullable: false, identity: true),
                        TransactionTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TransActionTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionTypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.Accounts", "TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Accounts", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Cards", "CardTypeID", "dbo.CardTypes");
            DropForeignKey("dbo.CardAccounts", "CardID", "dbo.Cards");
            DropForeignKey("dbo.CardAccounts", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "BalanceID", "dbo.Balances");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeID" });
            DropIndex("dbo.Cards", new[] { "CardTypeID" });
            DropIndex("dbo.CardAccounts", new[] { "AccountID" });
            DropIndex("dbo.CardAccounts", new[] { "CardID" });
            DropIndex("dbo.Accounts", new[] { "ClientID" });
            DropIndex("dbo.Accounts", new[] { "TransactionID" });
            DropIndex("dbo.Accounts", new[] { "BalanceID" });
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.CardTypes");
            DropTable("dbo.Cards");
            DropTable("dbo.CardAccounts");
            DropTable("dbo.Balances");
            DropTable("dbo.Accounts");
        }
    }
}
