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
                        duoAccount = c.Boolean(nullable: false),
                        accountAmount = c.Int(nullable: false),
                        TransactionID = c.Int(nullable: false),
                        Balance_BalanceID = c.Int(),
                        Card_CardID = c.Int(),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Balances", t => t.Balance_BalanceID)
                .ForeignKey("dbo.Cards", t => t.Card_CardID)
                .Index(t => t.Balance_BalanceID)
                .Index(t => t.Card_CardID);
            
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceID = c.Int(nullable: false, identity: true),
                        BalanceAmount = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CardID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        CardID = c.Int(nullable: false),
                        DateLog = c.String(),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Cards", t => t.CardID, cascadeDelete: true)
                .Index(t => t.CardID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionAmount = c.Int(nullable: false),
                        TransactionTypeID_TransActionTypeID = c.Int(),
                        Account_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeID_TransActionTypeID)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountID)
                .Index(t => t.TransactionTypeID_TransActionTypeID)
                .Index(t => t.Account_AccountID);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransActionTypeID = c.Int(nullable: false, identity: true),
                        TransactionTypeName = c.String(nullable: false),
                        Transaction_TransactionID = c.Int(),
                        Transaction_TransactionID1 = c.Int(),
                    })
                .PrimaryKey(t => t.TransActionTypeID)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID1)
                .Index(t => t.Transaction_TransactionID)
                .Index(t => t.Transaction_TransactionID1);
            
            CreateTable(
                "dbo.Clientaccounts",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientaccounts", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clientaccounts", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Transactions", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.TransactionTypes", "Transaction_TransactionID1", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "TransactionTypeID_TransActionTypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.TransactionTypes", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Logs", "CardID", "dbo.Cards");
            DropForeignKey("dbo.Accounts", "Card_CardID", "dbo.Cards");
            DropForeignKey("dbo.Accounts", "Balance_BalanceID", "dbo.Balances");
            DropIndex("dbo.Clientaccounts", "IX_ClientIDAccountID");
            DropIndex("dbo.TransactionTypes", new[] { "Transaction_TransactionID1" });
            DropIndex("dbo.TransactionTypes", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.Transactions", new[] { "Account_AccountID" });
            DropIndex("dbo.Transactions", new[] { "TransactionTypeID_TransActionTypeID" });
            DropIndex("dbo.Logs", new[] { "CardID" });
            DropIndex("dbo.Accounts", new[] { "Card_CardID" });
            DropIndex("dbo.Accounts", new[] { "Balance_BalanceID" });
            DropTable("dbo.Clients");
            DropTable("dbo.Clientaccounts");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Logs");
            DropTable("dbo.Cards");
            DropTable("dbo.Balances");
            DropTable("dbo.Accounts");
        }
    }
}
