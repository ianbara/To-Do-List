using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;
using ToDoList.Data.Models;

namespace ToDoList.Service
{
    /*
     * 
     * Service layer
     * All of our business logic will be created in a service layer, because the controllers should not contain any logic. 
     * This is so all our logic can be in one place and that the same logic can be unit tested with mocked data.
     * 
     */

    public class BoardService : IBoardService
    {
        private IUnitOfWork _uow;
        private IRepository<Board> _Board;

        public BoardService(IUnitOfWork uow)
        {
            _uow = uow;
            _Board = _uow.GetRepository<Board>();
        }

        public IEnumerable<Board> GetAll()
        {
            return _Board.GetAll();
        }

        public Board GetByID(int id)
        {
            try
            {
                return _Board.GetAll().Where(s => s.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure getting Board", ex);
            }
        }

        public void Create(Board Board)
        {
            _Board.Add(Board);
            _uow.Save();
        }

        public void Update(Board Board)
        {
            _Board.Update(Board);
            _uow.Save();
        }

        public void DeleteByID(int id)
        {
            try
            {
                Board model = _Board.GetAll().Where(s => s.Id == id).SingleOrDefault();
                _Board.Delete(model);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure deleting Board", ex);
            }
        }


        public void ToggleComplete(int id)
        {
            try
            {
                Board model = _Board.GetAll().Where(s => s.Id == id).SingleOrDefault();
                model.Completed = !model.Completed;
                _Board.Update(model);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure completing Board", ex);
            }
        }

    }
}
