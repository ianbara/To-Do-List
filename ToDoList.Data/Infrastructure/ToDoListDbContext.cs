using System.Data.Entity;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMap());

            base.OnModelCreating(modelBuilder);

        }
     

    }
}