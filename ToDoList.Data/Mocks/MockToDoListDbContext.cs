using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data.Infrastructure
{
    public class MockToDoListDbContext
    {
        public List<Note> Note
        {
            get
            {
                return new List<Note>
        {
            new Note
            {
                id = 1,
                SortOrder = 1,
                Name = "Make a Brew",
                StartDate = DateTime.Now
            },
            new Note
            {
                id = 2,
                SortOrder = 1,
                Name = "Note Appears Tomorrow",
                StartDate = DateTime.Now.AddDays(1)
            },
            new Note
            {
                id = 3,
                SortOrder = 2,
                Name = "Merge some code",
                StartDate = DateTime.Now.AddDays(1)
            }
        };
            }
        }
    }
}
