namespace Razzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameResults",
                c => new
                    {
                        GameResultId = c.Int(nullable: false, identity: true),
                        Player = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameResultId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameResults");
        }
    }
}
