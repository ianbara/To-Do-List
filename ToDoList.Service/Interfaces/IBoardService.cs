using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;
using ToDoList.Data.Models;

namespace ToDoList.Service
{
    public interface IBoardService
    {
        IEnumerable<Board> GetAll();
        Board GetByID(int id);
        void Create(Board note);
        void Update(Board note);
        void DeleteByID(int id);
        void ToggleComplete(int id);
    }
}
