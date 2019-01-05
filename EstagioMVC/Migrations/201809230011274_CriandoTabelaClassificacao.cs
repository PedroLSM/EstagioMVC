namespace EstagioMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoTabelaClassificacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Curso", "Classificacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Curso", "Classificacao");
        }
    }
}
