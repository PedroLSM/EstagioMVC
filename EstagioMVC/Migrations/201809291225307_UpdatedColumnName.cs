namespace EstagioMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedColumnName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Nome", c => c.String());
        }
    }
}
