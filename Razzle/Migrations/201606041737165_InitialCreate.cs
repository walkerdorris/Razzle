namespace Razzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Turns",
                c => new
                    {
                        TurnId = c.Int(nullable: false, identity: true),
                        RoundId = c.Int(nullable: false),
                        BoardLayout = c.String(),
                        Points = c.Int(nullable: false),
                        Word = c.String(),
                        Game_GameId = c.Int(),
                        Player_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.TurnId)
                .ForeignKey("dbo.Games", t => t.Game_GameId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerID)
                .Index(t => t.Game_GameId)
                .Index(t => t.Player_PlayerID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turns", "Player_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Turns", "Game_GameId", "dbo.Games");
            DropIndex("dbo.Turns", new[] { "Player_PlayerID" });
            DropIndex("dbo.Turns", new[] { "Game_GameId" });
            DropTable("dbo.Players");
            DropTable("dbo.Turns");
            DropTable("dbo.Games");
        }
    }
}
