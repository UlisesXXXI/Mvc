namespace jim.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevapropiedadenrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Activo", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Activo");
        }
    }
}
