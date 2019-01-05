namespace EstagioMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIntituicaoInTrainee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainee", "Instituicao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainee", "Instituicao");
        }
    }
}
