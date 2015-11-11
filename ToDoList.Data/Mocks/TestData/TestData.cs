using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Models;

namespace ToDoList.Data.Mocks.TestData
{
    public static class TestData
    {

        public static List<Board> GetTestBoards()
        {
            return new List<Board>
            {
                new Board {Id = 1, Name = "Board 1", NoteList = GetTestNotes()},
                new Board {Id = 2, Name = "Board 2"},
                new Board {Id = 3, Name = "Board 3"}
            };
        }

        public static List<Note> GetTestNotes()
        {
            return new List<Note>
            {
                new Note(1)
                {
                    SortOrder = 1,
                    Name = "Make a Brew",
                    StartDate = DateTime.Now,
                    BoardId =  1
                },
                new Note(2)
                {
                    SortOrder = 1,
                    Name = "Note Appears Tomorrow",
                    StartDate = DateTime.Now.AddDays(1),
                    BoardId =  1
                },
                new Note(3)
                {
                    SortOrder = 2,
                    Name = "Merge some code",
                    StartDate = DateTime.Now.AddDays(1),
                    BoardId =  2
                }
            };

        }
    }
}
