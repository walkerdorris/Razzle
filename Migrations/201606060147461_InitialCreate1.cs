namespace Razzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "PlayerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "PlayerName", c => c.String());
        }
    }
}
