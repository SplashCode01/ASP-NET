namespace SchoolDB.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjects", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.StudentSubjects", new[] { "Student_StudentID" });
            RenameColumn(table: "dbo.StudentSubjects", name: "Student_StudentID", newName: "StudentID");
            DropPrimaryKey("dbo.StudentSubjects");
            AlterColumn("dbo.StudentSubjects", "StudentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StudentSubjects", new[] { "StudentID", "SubjectID" });
            CreateIndex("dbo.StudentSubjects", "StudentID");
            AddForeignKey("dbo.StudentSubjects", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            DropColumn("dbo.Students", "IsDeleted");
            DropColumn("dbo.StudentSubjects", "PersonalID");
            DropColumn("dbo.Subjects", "Credits");
            DropColumn("dbo.Subjects", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subjects", "Credits", c => c.Byte(nullable: false));
            AddColumn("dbo.StudentSubjects", "PersonalID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.StudentSubjects", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentSubjects", new[] { "StudentID" });
            DropPrimaryKey("dbo.StudentSubjects");
            AlterColumn("dbo.StudentSubjects", "StudentID", c => c.Int());
            AddPrimaryKey("dbo.StudentSubjects", new[] { "PersonalID", "SubjectID" });
            RenameColumn(table: "dbo.StudentSubjects", name: "StudentID", newName: "Student_StudentID");
            CreateIndex("dbo.StudentSubjects", "Student_StudentID");
            AddForeignKey("dbo.StudentSubjects", "Student_StudentID", "dbo.Students", "StudentID");
        }
    }
}
