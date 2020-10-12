namespace _0702.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAllModelAndViewModelToDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Trainees", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Trainees", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.TraineeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TrainerTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(maxLength: 128),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.TopicId);
            
            AddColumn("dbo.Courses", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Trainees", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Trainees", "WorkingPlace", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Description", c => c.String());
            DropColumn("dbo.Courses", "CourseId");
            DropColumn("dbo.Trainees", "UserId");
            DropColumn("dbo.Trainees", "Email");
            DropColumn("dbo.Trainees", "Phone");
            DropColumn("dbo.Trainees", "ApplicationUser_Id");
            DropTable("dbo.Carts");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Trainees", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Trainees", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Trainees", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Trainees", "UserId", c => c.String());
            AddColumn("dbo.Courses", "CourseId", c => c.String());
            DropForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerTopics", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.TraineeCourses", "TraineeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.TrainerTopics", new[] { "TopicId" });
            DropIndex("dbo.TrainerTopics", new[] { "TrainerId" });
            DropIndex("dbo.TraineeCourses", new[] { "CourseId" });
            DropIndex("dbo.TraineeCourses", new[] { "TraineeId" });
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Trainees", "WorkingPlace");
            DropColumn("dbo.Trainees", "PhoneNumber");
            DropColumn("dbo.Courses", "Description");
            DropTable("dbo.TrainerTopics");
            DropTable("dbo.TraineeCourses");
            CreateIndex("dbo.Trainees", "ApplicationUser_Id");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Carts", "ProductId");
            CreateIndex("dbo.Carts", "CustomerId");
            AddForeignKey("dbo.Trainees", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "CustomerId", "dbo.AspNetUsers", "Id");
        }
    }
}
