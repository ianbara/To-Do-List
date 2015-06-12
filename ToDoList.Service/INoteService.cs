using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;

namespace ToDoList.Service
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetByID(int id);
        void Create(Note note);
        void Update(Note note);
        void DeleteByID(int id);
        void ToggleComplete(int id);
    }
}
