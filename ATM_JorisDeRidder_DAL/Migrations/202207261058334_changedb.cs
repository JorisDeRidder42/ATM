namespace ATM_JorisDeRidder_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "BirthDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
