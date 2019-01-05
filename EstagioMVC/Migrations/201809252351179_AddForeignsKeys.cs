namespace EstagioMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignsKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Historico", name: "Curso_Id", newName: "CursoId");
            RenameColumn(table: "dbo.Historico", name: "Trainee_Id", newName: "TraineeId");
            RenameIndex(table: "dbo.Historico", name: "IX_Curso_Id", newName: "IX_CursoId");
            RenameIndex(table: "dbo.Historico", name: "IX_Trainee_Id", newName: "IX_TraineeId");
            AddColumn("dbo.Curso", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Historico", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainee", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainee", "UserId");
            DropColumn("dbo.Historico", "UserId");
            DropColumn("dbo.Curso", "UserId");
            RenameIndex(table: "dbo.Historico", name: "IX_TraineeId", newName: "IX_Trainee_Id");
            RenameIndex(table: "dbo.Historico", name: "IX_CursoId", newName: "IX_Curso_Id");
            RenameColumn(table: "dbo.Historico", name: "TraineeId", newName: "Trainee_Id");
            RenameColumn(table: "dbo.Historico", name: "CursoId", newName: "Curso_Id");
        }
    }
}
