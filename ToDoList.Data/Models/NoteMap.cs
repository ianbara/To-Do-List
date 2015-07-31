using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data
{
    public class NoteMap : EntityTypeConfiguration<Note>
    {
          public NoteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Note");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.AllDay).HasColumnName("AllDay");
            this.Property(t => t.Completed).HasColumnName("Completed");
            this.Property(t => t.Reference).HasColumnName("Reference");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
        }
    }
}
