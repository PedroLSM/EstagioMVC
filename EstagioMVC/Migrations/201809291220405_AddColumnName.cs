namespace EstagioMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nome");
        }
    }
}
