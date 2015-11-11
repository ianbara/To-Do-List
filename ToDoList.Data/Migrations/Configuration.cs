using ToDoList.Data.Mocks.TestData;

namespace ToDoList.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoList.Data.ToDoListDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; 
            ContextKey = "ToDoList.Data.ToDoListDbContext";
        }

        protected override void Seed(ToDoList.Data.ToDoListDbContext context)
        {

            //var notes = TestData.GetTestNotes();
            //var boards = TestData.GetTestBoards();

            //notes.ForEach(s => context.Notes.Add(s));
            //context.SaveChanges();

            //boards.ForEach(s => context.Boards.Add(s));
            //context.SaveChanges();

            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
