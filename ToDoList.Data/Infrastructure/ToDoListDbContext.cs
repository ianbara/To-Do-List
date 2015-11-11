using System.Data.Entity;
using ToDoList.Data.Models;

namespace ToDoList.Data
{
    public partial class ToDoListDbContext : DbContext, IDbContext
    {
        static ToDoListDbContext()
        {
            //Database.SetInitializer<ToDoListDbContext>(null);
           // Configuration.LazyLoadingEnabled = false;
        }

        public ToDoListDbContext()
            : base("Name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMap());
            //modelBuilder.Configurations.Add(new BoardMap());

            base.OnModelCreating(modelBuilder);

        }
     

    }
}