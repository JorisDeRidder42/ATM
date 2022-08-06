namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Card_CardID", "dbo.Cards");
            DropForeignKey("dbo.Logs", "CardID", "dbo.Cards");
            DropForeignKey("dbo.TransactionTypes", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.TransactionTypes", "Transaction_TransactionID1", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Balance_BalanceID", "dbo.Balances");
            DropIndex("dbo.Accounts", new[] { "Balance_BalanceID" });
            DropIndex("dbo.Accounts", new[] { "Card_CardID" });
            DropIndex("dbo.Logs", new[] { "CardID" });
            DropIndex("dbo.Transactions", new[] { "Account_AccountID" });
            DropIndex("dbo.TransactionTypes", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.TransactionTypes", new[] { "Transaction_TransactionID1" });
            RenameColumn(table: "dbo.Accounts", name: "Balance_BalanceID", newName: "BalanceID");
            AddColumn("dbo.Accounts", "TransactionID", c => c.Int(nullable: false));
            AddColumn("dbo.Cards", "CardName", c => c.String());
            AddColumn("dbo.Cards", "LogID", c => c.Int(nullable: false));
            AddColumn("dbo.Cards", "AccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "BalanceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "BalanceID");
            CreateIndex("dbo.Accounts", "TransactionID");
            CreateIndex("dbo.Cards", "LogID");
            CreateIndex("dbo.Cards", "AccountID");
            AddForeignKey("dbo.Cards", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            AddForeignKey("dbo.Cards", "LogID", "dbo.Logs", "LogID", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "TransactionID", "dbo.Transactions", "TransactionID", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "BalanceID", "dbo.Balances", "BalanceID", cascadeDelete: true);
            DropColumn("dbo.Accounts", "Card_CardID");
            DropColumn("dbo.Logs", "CardID");
            DropColumn("dbo.Transactions", "Account_AccountID");
            DropColumn("dbo.TransactionTypes", "Transaction_TransactionID");
            DropColumn("dbo.TransactionTypes", "Transaction_TransactionID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionTypes", "Transaction_TransactionID1", c => c.Int());
            AddColumn("dbo.TransactionTypes", "Transaction_TransactionID", c => c.Int());
            AddColumn("dbo.Transactions", "Account_AccountID", c => c.Int());
            AddColumn("dbo.Logs", "CardID", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "Card_CardID", c => c.Int());
            DropForeignKey("dbo.Accounts", "BalanceID", "dbo.Balances");
            DropForeignKey("dbo.Accounts", "TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Cards", "LogID", "dbo.Logs");
            DropForeignKey("dbo.Cards", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Cards", new[] { "AccountID" });
            DropIndex("dbo.Cards", new[] { "LogID" });
            DropIndex("dbo.Accounts", new[] { "TransactionID" });
            DropIndex("dbo.Accounts", new[] { "BalanceID" });
            AlterColumn("dbo.Accounts", "BalanceID", c => c.Int());
            DropColumn("dbo.Cards", "AccountID");
            DropColumn("dbo.Cards", "LogID");
            DropColumn("dbo.Cards", "CardName");
            DropColumn("dbo.Accounts", "TransactionID");
            RenameColumn(table: "dbo.Accounts", name: "BalanceID", newName: "Balance_BalanceID");
            CreateIndex("dbo.TransactionTypes", "Transaction_TransactionID1");
            CreateIndex("dbo.TransactionTypes", "Transaction_TransactionID");
            CreateIndex("dbo.Transactions", "Account_AccountID");
            CreateIndex("dbo.Logs", "CardID");
            CreateIndex("dbo.Accounts", "Card_CardID");
            CreateIndex("dbo.Accounts", "Balance_BalanceID");
            AddForeignKey("dbo.Accounts", "Balance_BalanceID", "dbo.Balances", "BalanceID");
            AddForeignKey("dbo.Transactions", "Account_AccountID", "dbo.Accounts", "AccountID");
            AddForeignKey("dbo.TransactionTypes", "Transaction_TransactionID1", "dbo.Transactions", "TransactionID");
            AddForeignKey("dbo.TransactionTypes", "Transaction_TransactionID", "dbo.Transactions", "TransactionID");
            AddForeignKey("dbo.Logs", "CardID", "dbo.Cards", "CardID", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "Card_CardID", "dbo.Cards", "CardID");
        }
    }
}
