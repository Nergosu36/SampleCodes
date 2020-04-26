namespace MMOBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 30),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Login);
            
            CreateTable(
                "dbo.Champions",
                c => new
                    {
                        ChampionID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Level = c.Int(nullable: false),
                        AccountLogin = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ChampionID)
                .ForeignKey("dbo.Accounts", t => t.AccountLogin)
                .Index(t => t.AccountLogin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Champions", "AccountLogin", "dbo.Accounts");
            DropIndex("dbo.Champions", new[] { "AccountLogin" });
            DropTable("dbo.Champions");
            DropTable("dbo.Accounts");
        }
    }
}
