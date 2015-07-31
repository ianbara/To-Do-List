namespace ToDoList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Reference = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Details = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        AllDay = c.Boolean(nullable: false),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Note");
        }
    }
}
