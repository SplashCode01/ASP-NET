namespace SchoolDB.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Byte(nullable: false),
                        Sex = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        PersonalID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        Point = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => new { t.PersonalID, t.SubjectID })
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Credits = c.Byte(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.StudentSubjects", new[] { "Student_StudentID" });
            DropIndex("dbo.StudentSubjects", new[] { "SubjectID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentSubjects");
            DropTable("dbo.Students");
        }
    }
}
