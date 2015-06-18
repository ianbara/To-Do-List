using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;

namespace ToDoList.Data
{
    public class Note
    {
        public Note()
        {
            SetDefaultValue();
        }

        public Note(int id)
        {
            Id = id;
            SetDefaultValue();
        }
        [Required]
        public int Id { get; private set; }
        public int Reference { get; set; }
        public int SortOrder { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool AllDay { get; set; }
        public bool Completed { get; set; }

        private void SetDefaultValue()
        {
            StartDate = DateTime.Now;
            SortOrder = 0;
            AllDay = true;
        }
    }
}
