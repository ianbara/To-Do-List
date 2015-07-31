using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ToDoList.Data.Models
{
    
    public class Board
    {

        public Board()
        {
            NoteList = new Collection<Note>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Note> NoteList { get; set; }
    }
}
