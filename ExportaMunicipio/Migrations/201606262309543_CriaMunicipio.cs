namespace ExportaMunicipio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaMunicipio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ufID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UFs", t => t.ufID, cascadeDelete: true)
                .Index(t => t.ufID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Municipios", "ufID", "dbo.UFs");
            DropIndex("dbo.Municipios", new[] { "ufID" });
            DropTable("dbo.Municipios");
        }
    }
}
