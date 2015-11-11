using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Mocks.TestData;
using ToDoList.Data.Models;

namespace ToDoList.Data.Infrastructure
{
    public class MockToDoListDbContext
    {
        public List<Board> Board
        {
            get { return TestData.GetTestBoards(); }
        }

        public List<Note> Note
        {
            get { return TestData.GetTestNotes(); }
        }



    }
}
