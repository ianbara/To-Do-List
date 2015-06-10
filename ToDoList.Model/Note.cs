using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data
{
    public class Note
    {
        public int id { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AllDay { get; set; }
        public bool Completed { get; set; }
    }
}
