namespace ExportaMunicipio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UFs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sigla = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UFs");
        }
    }
}
