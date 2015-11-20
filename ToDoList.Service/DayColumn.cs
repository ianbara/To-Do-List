using System;
using System.Collections.Generic;
using ToDoList.Data;

namespace ToDoList.Service
{
    public class DayColumn
    {
        public DayColumn()
        {
            Notes = new List<Note>();
        }

        public DateTime DataDate { get; set; }
        public string Day { get { return DataDate.DayOfWeek.ToString(); } }

        public string Date { get
        {
            return string.Format("{0} {1}, {2}", DataDate.Month, DataDate.Day, DataDate.Year);
        }}


        public string Present
        {
            get { return (DataDate == DateTime.Today ? "present" : "future"); }
        }


        public List<Note> Notes { get; set; }
    }
}