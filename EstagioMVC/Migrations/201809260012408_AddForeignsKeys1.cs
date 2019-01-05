namespace EstagioMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignsKeys1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Curso", new[] { "User_Id" });
            DropIndex("dbo.Historico", new[] { "User_Id" });
            DropIndex("dbo.Trainee", new[] { "User_Id" });
            DropColumn("dbo.Curso", "UserId");
            DropColumn("dbo.Historico", "UserId");
            DropColumn("dbo.Trainee", "UserId");
            RenameColumn(table: "dbo.Curso", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Historico", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Trainee", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Curso", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Historico", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Trainee", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Curso", "UserId");
            CreateIndex("dbo.Historico", "UserId");
            CreateIndex("dbo.Trainee", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trainee", new[] { "UserId" });
            DropIndex("dbo.Historico", new[] { "UserId" });
            DropIndex("dbo.Curso", new[] { "UserId" });
            AlterColumn("dbo.Trainee", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Historico", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Curso", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Trainee", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Historico", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Curso", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Trainee", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Historico", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Curso", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trainee", "User_Id");
            CreateIndex("dbo.Historico", "User_Id");
            CreateIndex("dbo.Curso", "User_Id");
        }
    }
}
