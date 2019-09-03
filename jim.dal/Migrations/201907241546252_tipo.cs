namespace jim.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        TipoID = c.String(nullable: false, maxLength: 128),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tipoes");
        }
    }
}
